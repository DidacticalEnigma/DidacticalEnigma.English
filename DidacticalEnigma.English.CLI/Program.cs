using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using DidacticalEnigma.English.Core;
using DidacticalEnigma.English.Parsing;
using DidacticalEnigma.English.Parsing.Models;
using NHyphenator;
using NHyphenator.Loaders;
using Optional;

namespace DidacticalEnigma.English.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordnet = new WordnetDictionary(
                "/media/milleniumbug/stuff/asdf/english_resources/english-wordnet-2020.xml",
                "/media/milleniumbug/stuff/asdf/english_resources/wordnet.cache");
            
            var latin1 = Encoding.GetEncoding("iso-8859-1");
            var hyphenationList = HyphenationFileReader.ReadFromFile("/home/milleniumbug/dokumenty/asdf/english_resources/delphiforfun/Syllables.txt", ((char)183).ToString(), latin1)
                    .Concat(HyphenationFileReader.ReadFromFile("/home/milleniumbug/dokumenty/asdf/english_resources/delphiforfun/SyllablesUpdate.txt", " ", latin1))
                    .OrderBy(hyphentationInfo => hyphentationInfo.Word, StringComparer.InvariantCulture)
                    .ToList();
            string? line;
            
            var loader = new ResourceHyphenatePatternsLoader(HyphenatePatternsLanguage.EnglishUs);
            Hyphenator hypenator = new Hyphenator(loader, "-");

            while (true)
            {
                Console.Write("> ");
                line = Console.ReadLine();
                if (line == null)
                    break;
                
                var resultOpt = BinarySearch(
                    hyphenationList,
                    (list, index) => list[index],
                    hyphenationList.Count,
                    line,
                    info => info.Word,
                    StringComparer.InvariantCulture);
                resultOpt.Match(result =>
                {
                    Console.WriteLine(string.Join("-", result.element.Syllables));                    
                }, 
                () =>
                {
                    Console.WriteLine("fall back to generic hyphenator");
                    Console.WriteLine(hypenator.HyphenateText(line));
                });
                var lookupResult = wordnet.Lookup(line);
                foreach (var entry in lookupResult)
                {
                    Console.WriteLine($"{line} ({entry.PartOfSpeech})");
                    foreach (var definition in entry.Definition)
                    {
                        Console.WriteLine(definition);
                    }

                    foreach (var example in entry.Examples)
                    {
                        Console.WriteLine($"- {example}");
                    }
                }
            }
        }
        
        public static Option<(T element, int index)> BinarySearch<T, TCollection, TKey>(
            TCollection collection,
            Func<TCollection, int, T> lookup,
            int len,
            TKey lookupKey,
            Func<T, TKey> selector,
            IComparer<TKey>? comparer = null)
        {
            comparer ??= Comparer<TKey>.Default;
            int left = 0;
            int right = len - 1;
            while (left <= right)
            {
                var m = GetMidpoint(left, right);
                var record = lookup(collection, m);
                var recordKey = selector(record);
                switch (comparer.Compare(recordKey, lookupKey))
                {
                    case var x when x < 0:
                        left = m + 1;
                        break;
                    case var x when x > 0:
                        right = m - 1;
                        break;
                    default:
                        return Option.Some((record, m));
                }
            }

            return Option.None<(T element, int index)>();
        }

        private static int GetMidpoint(int l, int r)
        {
            // To replace if you suffer overflows
            return (l + r) / 2;
        }
    }
}