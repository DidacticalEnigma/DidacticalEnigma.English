using System.Web;
using HtmlAgilityPack;

namespace DidacticalEnigma.English.Core.Scraping;

public static class ScrapingUtils
{
    public static string GetInnerTextForReal(this HtmlNode node)
    {
        // https://github.com/zzzprojects/html-agility-pack/issues/427
        return HttpUtility.HtmlDecode(node.InnerText);
    }
}