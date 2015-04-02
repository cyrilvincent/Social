using HtmlAgilityPack;
using Social.ServicesLibrary.Crawlers.Common;
using Social.RepositoriesLibrary.Entities.Crawler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Social.ServicesLibrary.Crawlers
{
    public class EurekaSanteMedicineCrawler : AbstractCrawler<Medicine>
    {
        public override void Crawl()
        {
            Crawl("http://www.eurekasante.fr/medicaments/vidal-famille/medicament-ddolip01-DOLIPRANE.html", Encoding.UTF8);
        }

        public AHref AHref { get; set; }
        public MedicineType Type { get; set; }

        public override Medicine Crawl(string url, Encoding encoding)
        {
            base.Crawl(url, encoding);
            Medicine m = null;
            HtmlDocument doc = Load(url, encoding);
            if (doc != null)
            {
                HtmlNode h1 = doc.DocumentNode.SelectSingleNode("//h1");
                if (h1 != null)
                {
                    m = new Medicine { AHref = AHref };
                    m.Name = h1.InnerText;
                    HtmlNode div = doc.DocumentNode.SelectSingleNode("//div[@class=\"fiche\"]");
                    if(Type == MedicineType.Phyto)
                        div = doc.DocumentNode.SelectSingleNode("//td[@class=\"modifydate\"]").ParentNode.ParentNode;
                    Remove(div, ".//div[@class=\"moduletable indicmedicmaladie\"]");
                    if (Type == MedicineType.Phyto)
                        Remove(div, ".//td[@class=\"modifydate\"]");
                    RemoveAHref(div);
                    RemoveComments(div);
                    ReplaceImgSrc(div);
                    RemoveAttributes(div, "class");
                    RemoveItemsAttributes(div);
                    m.Content = div.OuterHtml.Replace("eurekasante", "").Replace("eureka", "").Replace("€", "Euro").Replace("TOREPLACE", "http://www.eurekasante.fr"); ;
                }
            }
            return m;
        }

        

        
    }
}
