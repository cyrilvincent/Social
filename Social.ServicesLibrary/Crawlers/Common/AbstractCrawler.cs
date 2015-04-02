using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Social.ServicesLibrary.Crawlers.Common
{
    public abstract class AbstractCrawler<T> : ICrawler<T>
    {
        public delegate void CrawlerHandler(string msg);
        public CrawlerHandler CrawlingEvent;

        public virtual void Crawl()
        {
            throw new NotImplementedException();
        }
        public virtual T Crawl(string url)
        {
            return Crawl(url, Encoding.UTF8);
        }
        public virtual T Crawl(string url, Encoding encoding)
        {
            if (CrawlingEvent != null)
                CrawlingEvent("Open " + url);
            Console.WriteLine("Open " + url);
            return default(T);
        }

        public string Open(string url, Encoding encoding)
        {
            WebClient client = new WebClient();
            client.Encoding = encoding;
            string content = client.DownloadString(url);
            client.Dispose();
            return content;
        }

        public HtmlDocument Load(string url, Encoding encoding)
        {
            HtmlDocument doc = null;
            try
            {
                string s = Open(url, encoding);
                doc = new HtmlDocument();
                doc.LoadHtml(s);
            }
            catch (Exception ex)
            {
                doc = null;
                Console.WriteLine(ex);
            }
            return doc;
        }

        public void Remove(HtmlNode node, string xpath)
        {
            HtmlNode remove = node.SelectSingleNode(xpath);
            if (remove != null)
                remove.Remove();
        }

        public void RemoveAHref(HtmlNode node)
        {
            HtmlNodeCollection col = node.SelectNodes(".//a");
            if (col != null)
                foreach (HtmlNode replace in col)
                {
                    if(replace.ParentNode != null)
                        replace.ParentNode.ReplaceChild(replace.FirstChild, replace);
                }
        }

        public void RemoveComments(HtmlNode node)
        {
            HtmlNodeCollection col = node.SelectNodes(".//comment()");
            if (col != null)
                foreach (HtmlNode replace in col)
                {
                    replace.Remove();
                }
        }

        public void RemoveItemsAttributes(HtmlNode node)
        {
            RemoveAttributes(node, "itemprop");
            RemoveAttributes(node, "itemtype");
            RemoveAttributes(node, "itemscope");
        }

        public void RemoveAttributes(HtmlNode node, string attrName)
        {
            HtmlNodeCollection col = node.SelectNodes(".//@"+attrName);
            if (col != null)
                foreach (HtmlNode n in col)
                {
                    n.Attributes.Remove(attrName);
                }
        }

        public void ReplaceImgSrc(HtmlNode node, string s = "TOREPLACE")
        {
            HtmlNodeCollection col = node.SelectNodes(".//img");
            if (col != null)
                foreach (HtmlNode i in col)
                {
                    string src = i.GetAttributeValue("src", null);
                    if (src != null)
                    {
                        if (src.StartsWith("/"))
                            i.SetAttributeValue("src", s + src);
                    }

                }
        }



    }
}
