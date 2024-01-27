using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DidacticalEnigma.English.Core;
using DidacticalEnigma.English.Core.Scraping;
using DidacticalEnigma.English.Parsing;
using DidacticalEnigma.English.Parsing.Models;
using NHyphenator;
using NHyphenator.Loaders;
using Optional;
using ScrapySharp.Network;

namespace DidacticalEnigma.English.CLI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var wordnet = new WordnetDictionary(
                "/home/milleniumbug/dokumenty/asdf/english_resources/english-wordnet-2020.xml",
                "/home/milleniumbug/dokumenty/asdf/english_resources/wordnet.cache");
            
            var latin1 = Encoding.GetEncoding("iso-8859-1");
            var hyphenationList = HyphenationFileReader.ReadFromFile("/home/milleniumbug/dokumenty/asdf/english_resources/delphiforfun/Syllables.txt", ((char)183).ToString(), latin1)
                    .Concat(HyphenationFileReader.ReadFromFile("/home/milleniumbug/dokumenty/asdf/english_resources/delphiforfun/SyllablesUpdate.txt", " ", latin1))
                    .OrderBy(hyphentationInfo => hyphentationInfo.Word, StringComparer.InvariantCulture)
                    .ToList();
            string? line;

            if(args.Contains("-"))
            {
                var loader = new ResourceHyphenatePatternsLoader(HyphenatePatternsLanguage.EnglishUs);
                Hyphenator genericHyphenator = new Hyphenator(loader, "-");

                var hyphenator = MakeWordHyphenator(hyphenationList, genericHyphenator);
                RegularLoop(wordnet, hyphenator);
            }
            else
            {
                await using var hyphenator = new MerriamWebsterScraperHyphenator(
                    await SimpleJsonCache.CreateAsync(
                        "/home/milleniumbug/dokumenty/asdf/english_resources/merriam_webster_hyphenation.json"),
                    new CachingScraper("/home/milleniumbug/dokumenty/asdf/english_resources/merriamwebsterpages",
                        new ScrapingBrowser()
                        {
                            Encoding = Encoding.UTF8
                        }));
                await HyphenateClipboard(hyphenator);
            }
        }

        private static async Task HyphenateClipboard(MerriamWebsterScraperHyphenator hyphenator)
        {
            
            var clipboardWatcher = new ClipwatchSharp.ClipboardWatcher();
            clipboardWatcher.ClipboardChanged += async (sender, clipboard) =>
            {
                Console.WriteLine(await Hyphenate(clipboard));
            };
            clipboardWatcher.Start();
            string? line = null;
            while ((line = Console.ReadLine()) != null)
            {
                Console.WriteLine(Hyphenate(line));
            }

            async Task<string> Hyphenate(string clipboard)
            {
                var noPunctuation = new string(clipboard.Where(c => !char.IsPunctuation(c) || c == '\'' || c == '-').ToArray());
                var hyphenated = new List<string>();
                foreach (var word in noPunctuation.Split())
                {
                    if (Regex.IsMatch(word, "^[A-Za-z][A-Za-z'-]*$"))
                    {
                        hyphenated.Add(string.Join("-", await hyphenator.Lookup(word)));                        
                    }
                    else
                    {
                        hyphenated.Add(word);
                    }
                }

                await hyphenator.SaveCacheAsync();
                return string.Join(" ", hyphenated);
            }
        }

        private static void RegularLoop(WordnetDictionary wordnet, Func<string, string> hyphenator)
        {
            string? line;
            while (true)
            {
                Console.Write("> ");
                line = Console.ReadLine();
                if (line == null)
                    break;

                Console.WriteLine(hyphenator(line));
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

        private static Func<string, string> MakeWordHyphenator(List<HyphenationInfo> hyphenationList, Hyphenator hypenator)
        {
            return word =>
            {
                var resultOpt = BinarySearch(
                    hyphenationList,
                    (list, index) => list[index],
                    hyphenationList.Count,
                    word,
                    info => info.Word,
                    StringComparer.InvariantCulture);
                return resultOpt
                    .Map(
                        result =>
                            string.Join("-", result.element.Syllables))
                    .ValueOr(() =>
                        hypenator.HyphenateText(word));
            };
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