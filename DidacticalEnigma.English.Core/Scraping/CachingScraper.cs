#nullable enable
using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DidacticalEnigma.English.Core.Caching;
using HtmlAgilityPack;
using ScrapySharp.Network;

namespace DidacticalEnigma.English.Core.Scraping;

public class CachingScraper
{
    private readonly ScrapingBrowser _browser;
    private readonly ICache<string, string> _cache;

    public CachingScraper(
        ScrapingBrowser browser,
        ICache<string, string> cache)
    {
        _browser = browser;
        _cache = cache;
    }

    public async Task<WebDocument> DownloadAsync(string url)
    {
        var html = new HtmlDocument();

        var rawHtml = await _cache.Get(url);
        if(rawHtml != null)
        {
            html.LoadHtml(rawHtml);
        }
        else
        {
            try
            {
                rawHtml = await _browser.DownloadStringAsync(new Uri(url));
                await _cache.Set(url, rawHtml);
            }
            catch (WebException ex)
            {
                var status = ex.Status;
                var code = (ex.Response as HttpWebResponse)?.StatusCode;
                if (code == null)
                {
                    throw;
                }
                rawHtml =
                    $"<html>{HttpUtility.HtmlEncode(status.ToString())}<br>{HttpUtility.HtmlEncode(code.ToString())}</html>";
                await _cache.Set(url, rawHtml);
            }

            html.LoadHtml(rawHtml);
        }

        return new WebDocument(html, url);
    }
}