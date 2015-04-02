using HtmlAgilityPack;
using Social.RepositoriesLibrary.Entities.Crawler;
using Social.ServicesLibrary.Crawlers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.ServicesLibrary.Crawlers
{
    public class PreviewCrawler : AbstractCrawler<Preview>
    {
        public override Preview Crawl(string url, Encoding encoding)
        {
            Preview p = null;
            base.Crawl(url, encoding);
            HtmlDocument doc = Load(url, encoding);
            if (doc != null)
            {
                p = new Preview { Url = url };
                p.Host = new Uri(url).Host;
                HtmlNode node = doc.DocumentNode.SelectSingleNode("//title");
                if (node != null) p.Title = node.InnerText;
                if (p.Title != null)
                {
                    p.Title = p.Title.Trim();
                    p.Summary = p.Title;
                }
                node = doc.DocumentNode.SelectSingleNode("//meta[@name=\"description\"]");
                if (node != null) p.Summary = node.GetAttributeValue("content", p.Summary);
                node = doc.DocumentNode.SelectSingleNode("//meta[@property=\"og:description\"]");
                if (node != null) p.Summary = node.GetAttributeValue("content", p.Summary);
                HtmlNode body = doc.DocumentNode.SelectSingleNode("//body");
                if (body != null)
                {
                    IEnumerable<HtmlNode> nodes = body.SelectNodes(".//h1");
                    if (node != null) p.Title = nodes.Last().InnerText;
                    Remove(body, ".//script");
                    Remove(body, ".//noscript");
                    HtmlNodeCollection col = body.SelectNodes(".//img");
                    if (col != null)
                    {
                        nodes = col.OrderByDescending(n => n.GetAttributeValue("width", 1) * n.GetAttributeValue("height", 1));
                        nodes = nodes.Where(n => n.GetAttributeValue("height", 100) > 50 && n.GetAttributeValue("height", 50) < 500);
                        nodes = nodes.Where(n => !(n.GetAttributeValue("src", "").Contains("pixel")) && !(n.GetAttributeValue("src", "").Contains("blank")));
                        if (nodes.Count() > 0)
                        {
                            p.ImageUrls = nodes.Where(n => (n.GetAttributeValue("src", null) != null) && (n.GetAttributeValue("src", null) != "")).Take(5).Select(n => n.GetAttributeValue("src", null).Trim()).ToList();
                        }

                    }
                    if (p.Url.Contains("www.youtube.com/watch"))
                    {
                        string id = p.Url.Substring(p.Url.LastIndexOf("v=") + 2);
                        if (id.Contains("&")) id = id.Substring(0, id.IndexOf("&"));
                        p.IFrameUrl = "//www.youtube.com/embed/" + id;
                    }
                    else if (p.Url.Contains("www.dailymotion.com/video"))
                    {
                        p.IFrameUrl = "//www.dailymotion.com/embed/video/" + p.Url.Substring(p.Url.LastIndexOf("/") + 1, 7);
                    }
                    else
                    {
                        node = body.SelectSingleNode(".//iframe[@src]");
                        if (node != null) p.IFrameUrl = node.GetAttributeValue("src", "").Trim();
                        if (p.IFrameUrl!= null && !(p.IFrameUrl.ToLower().Contains("youtube") || p.IFrameUrl.ToLower().Contains("dailymotion"))) p.IFrameUrl = null;
                    }
                    if (p.Summary == null || p.Summary == p.Title)
                    {
                        col = body.SelectNodes(".//p");
                        if(col != null)
                            node = col.OrderByDescending(n => n.InnerText.Length).FirstOrDefault();
                        if (node != null) p.Summary = node.InnerText;
                    }
                    if (p.Summary != null) p.Summary = p.Summary.Trim();
                }
                if (encoding == Encoding.UTF8 && p.Summary != null && p.Title != null)
                    if ((p.Title + p.Summary50).Contains("�"))
                        p = Crawl(url, Encoding.GetEncoding("iso-8859-1"));
            }
            return p;
        }
    }
}
