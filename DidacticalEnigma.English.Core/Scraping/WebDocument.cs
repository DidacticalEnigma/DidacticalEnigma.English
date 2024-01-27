using HtmlAgilityPack;

namespace DidacticalEnigma.English.Core.Scraping;

public class WebDocument
{
    public HtmlDocument Document { get; }

    public string Url { get; }
    
    public string Id { get; }

    public WebDocument(HtmlDocument document, string url, string id)
    {
        Document = document;
        Url = url;
        Id = id;
    }
}