using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DidacticalEnigma.English.Core.Scraping;
using HtmlAgilityPack;
using ScrapySharp.Extensions;

namespace DidacticalEnigma.English.Core;

public class MerriamWebsterScraperHyphenator : IDisposable, IAsyncDisposable
{
    private readonly SimpleJsonCache _cache;
    private readonly CachingScraper _scraper;
    private readonly CultureInfo enUsCultureInfo = new CultureInfo("en-US");

    public MerriamWebsterScraperHyphenator(SimpleJsonCache cache, CachingScraper scraper)
    {
        _cache = cache;
        _scraper = scraper;
    }

    public void Dispose()
    {
        _cache.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _cache.DisposeAsync();
    }

    private string Normalize(string word)
    {
        return word.ToLower(enUsCultureInfo);
    }

    public async Task<IReadOnlyList<string>> Lookup(string word)
    {
        word = Normalize(word);
        if (_cache.TryGetValue(word, out IReadOnlyList<string> split))
        {
            return split;
        }
        else
        {
            var scrape = new ReadOnlyCollection<string>(await Scrape(word));
            _cache[word] = scrape;
            return scrape;
        }
    }

    private async Task<string[]> Scrape(string word)
    {
        var webDocument = await _scraper.DownloadAsync($"https://www.merriam-webster.com/dictionary/{HttpUtility.UrlEncode(word)}");
        var html = webDocument.Document;

        var nodes = html.DocumentNode.CssSelect(".entry-header .word-syllables-entry");
        var innerText = nodes.FirstOrDefault()?.GetInnerTextForReal();
        var wordToSplit = innerText?.Trim().Replace("\u200B", "") ?? word;
        return wordToSplit.Split("·", StringSplitOptions.TrimEntries);
    }
}