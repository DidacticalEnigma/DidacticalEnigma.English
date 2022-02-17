using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using DidacticalEnigma.English.Parsing.Models;
using TinyIndex;

namespace DidacticalEnigma.English.Core
{
    public class WordnetDictionary
    {
        private static Dictionary<TKey, IReadOnlyList<TValue>> ToMultiDictionary<TInput, TKey, TValue>(
            IEnumerable<TInput> elements,
            Func<TInput, TKey> keySelector,
            Func<TInput, TValue> valueSelector)
        {
            var dictionary = new Dictionary<TKey, IReadOnlyList<TValue>>();
            foreach (var element in elements)
            {
                var key = keySelector(element);
                var value = valueSelector(element);
                if (dictionary.TryGetValue(key, out var list))
                {
                    // we can be sure it will be List<T> because we put it there in the first place
                    var writableList = (List<TValue>) list;
                    writableList.Add(value);
                }
                else
                {
                    dictionary[key] = new List<TValue>() { value };
                }
            }

            return dictionary;
        }
        
        private static XmlSerializer xmlSerializer = new XmlSerializer(typeof(LexicalResource));

        private static readonly Guid Version = new Guid("02E3C78B-3840-4885-95D2-DBDFB7989895");

        private TinyIndex.Database db;
        
        private IReadOnlyDiskArray<KeyValuePair<string, IReadOnlyList<WordnetDictionaryMeaning>>> entries;

        private static IEnumerable<KeyValuePair<string, IReadOnlyList<WordnetDictionaryMeaning>>> CreateEntries(Stream stream)
        {
            var lexicalResource = (LexicalResource) xmlSerializer.Deserialize(stream);
            var lexicon = lexicalResource.Lexicons[0];

            var lexicalEntries = ToMultiDictionary(
                lexicon.LexicalEntries
                    .SelectMany(entry =>
                        (entry.Forms ?? Enumerable.Empty<Form>())
                        .Select(form => new KeyValuePair<string, LexicalEntry>(form.WrittenForm, entry)).Concat(new[]
                            {new KeyValuePair<string, LexicalEntry>(entry.Lemma.WrittenForm, entry)})
                        .Distinct()),
                kvp => kvp.Key,
                kvp => kvp.Value);
            var synsets = lexicon.Synsets.ToDictionary(synset => synset.Id, synset => synset);

            foreach (var entry in lexicalEntries)
            {
                foreach (var lexicalEntry in entry.Value)
                {
                    var key = entry.Key;
                    yield return new KeyValuePair<string, IReadOnlyList<WordnetDictionaryMeaning>>(
                        key,
                        (lexicalEntry.Senses ?? Enumerable.Empty<Sense>())
                        .Select(sense =>
                        {
                            var synset = synsets[sense.Synset];
                            return new WordnetDictionaryMeaning(
                                partOfSpeech: lexicalEntry.Lemma.PartOfSpeech,
                                word: lexicalEntry.Lemma.WrittenForm,
                                definition: (synset.Definitions ?? Enumerable.Empty<Definition>()).Select(def => def.Text ?? "").ToList(),
                                examples: (synset.Examples ?? Enumerable.Empty<Example>()).Select(example => example.Text ?? "").ToList());
                        })
                        .ToList());                    
                }
            }
        }

        private void Init(Stream stream, string cachePath)
        {
            var entrySerializer = Serializer.ForKeyValuePair(
                Serializer.ForStringAsUtf8(),
                Serializer.ForReadOnlyList(
                    Serializer.ForComposite()
                        .With(Serializer.ForEnum<PartOfSpeech>())
                        .With(Serializer.ForStringAsUtf8())
                        .With(Serializer.ForReadOnlyList(Serializer.ForStringAsUtf8()))
                        .With(Serializer.ForReadOnlyList(Serializer.ForStringAsUtf8()))
                        .Create()
                        .Mapping(
                            raw => new WordnetDictionaryMeaning(
                                (PartOfSpeech) raw[0],
                                (string) raw[1],
                                (IReadOnlyList<string>) raw[2],
                                (IReadOnlyList<string>) raw[3]),
                            meaning => new object[]
                            {
                                meaning.PartOfSpeech,
                                meaning.Word,
                                meaning.Definition,
                                meaning.Examples
                            })));

            db = TinyIndex.Database.CreateOrOpen(cachePath, Version)
                .AddIndirectArray(entrySerializer, db => CreateEntries(stream),
                    x => x.Key,
                    StringComparer.Ordinal)
                .Build();

            entries = db.Get<KeyValuePair<string, IReadOnlyList<WordnetDictionaryMeaning>>>(0,
                new LruCache<long, KeyValuePair<string, IReadOnlyList<WordnetDictionaryMeaning>>>(64));
        }

        public IEnumerable<WordnetDictionaryMeaning> Lookup(string word)
        {
            var (element, id) = entries.BinarySearch(word, kvp => kvp.Key, StringComparer.Ordinal);
            if (id == -1)
            {
                return Enumerable.Empty<WordnetDictionaryMeaning>();
            }
            else
            {
                return element.Value;
            }
        }

        public WordnetDictionary(string xmlPath, string cachePath)
        {
            using (var stream = File.OpenRead(xmlPath))
            {
                Init(stream, cachePath);
            }
        }
    }

    public class WordnetDictionaryMeaning
    {
        public WordnetDictionaryMeaning(PartOfSpeech partOfSpeech, string word, IReadOnlyList<string> definition, IReadOnlyList<string> examples)
        {
            PartOfSpeech = partOfSpeech;
            Word = word;
            Definition = definition;
            Examples = examples;
        }

        public PartOfSpeech PartOfSpeech { get; }
        
        public string Word { get; set; }
        
        public IReadOnlyList<string> Definition { get; }
        
        public IReadOnlyList<string> Examples { get; }
    }
}