using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
namespace Social.ServicesLibrary.Crawlers.Common
{
    public interface ICrawler<T>
    {
        void Crawl();
        T Crawl(string url);
        T Crawl(string url, System.Text.Encoding encoding);
        string Open(string url, System.Text.Encoding encoding);

        HtmlDocument Load(string url, Encoding encoding);
    }
}
