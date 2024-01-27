using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;
using ScrapySharp.Network;

namespace DidacticalEnigma.English.Core.Scraping;

public class CachingScraper
{
    private readonly string _documentStorageDirectoryPath;
    private readonly ScrapingBrowser _browser;

    public CachingScraper(string documentStorageDirectoryPath, ScrapingBrowser browser)
    {
        _documentStorageDirectoryPath = documentStorageDirectoryPath;
        _browser = browser;
    }

    public async Task<WebDocument> DownloadAsync(string url)
    {
        using (var hasher = SHA1.Create())
        {
            var hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(url));
            var id = BitConverter.ToString(hash).Replace("-", "");
            var filename = id + ".html";
            var path = Path.Combine(_documentStorageDirectoryPath, filename);
            var html = new HtmlDocument();

            try
            {
                html.LoadHtml(await File.ReadAllTextAsync(path));
            }
            catch (FileNotFoundException)
            {
                string p;
                try
                {
                    p = await _browser.DownloadStringAsync(new Uri(url));
                }
                catch (WebException ex)
                {
                    p =
                        $"<html>{HttpUtility.HtmlEncode(ex.Status.ToString())}<br>{HttpUtility.HtmlEncode(((ex.Response as HttpWebResponse)?.StatusCode).ToString())}</html>";
                }
                await File.WriteAllTextAsync(path, p);
                html.LoadHtml(p);
            }

            return new WebDocument(html, url, id);
        }
    }
}