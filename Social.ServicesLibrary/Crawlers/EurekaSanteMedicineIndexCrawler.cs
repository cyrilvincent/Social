using HtmlAgilityPack;
using Social.ServicesLibrary.Crawlers.Common;
using Social.RepositoriesLibrary.Entities.Crawler;
using Social.RepositoriesLibrary.Repositories.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Social.ServicesLibrary.Crawlers
{
    public class EurekaSanteMedicineIndexCrawler : AbstractCrawler<List<AHref>>
    {
        public const string StartUrlMedicament = "http://www.eurekasante.fr/medicaments/alphabetique/recherche/liste-medicament-{0}.html";
        public const string StartUrlPara = "http://www.eurekasante.fr/parapharmacie/alphabetique/recherche/liste-produits-{0}.html";
        public const string StartUrlPhyto = "http://www.eurekasante.fr/parapharmacie/phytotherapie-plantes";

        public override void Crawl()
        {
            Crawl(MedicineType.Medicament, StartUrlMedicament);
            Crawl(MedicineType.Para, StartUrlPara);
            Crawl(MedicineType.Phyto, StartUrlPhyto);
        }

        public List<Medicine> Crawl(MedicineType type, string startUrl)
        {
            string s = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            //string s = "A";
            //string s = "HIJKLMNOPQRSTUVWXYZ";
            if(type == MedicineType.Phyto)
                s = "A";
            List<Medicine> medicines = new List<Medicine>();
            foreach (char c in s.ToArray())
            {
                string url = startUrl;
                if(type != MedicineType.Phyto)
                    url = String.Format(startUrl, c);
                List<AHref> l = Crawl(url, Encoding.UTF8, type);
                foreach (AHref a in l)
                {
                    EurekaSanteMedicineCrawler crawler = new EurekaSanteMedicineCrawler { AHref = a, Type = type };
                    Medicine m = crawler.Crawl("http://www.eurekasante.fr" + a.HRef, Encoding.UTF8);
                    if (m != null)
                    {
                        m.Type = type;
                        medicines.Add(m);
                        MedicineFileRepository r = new MedicineFileRepository();
                        r.Prefix = "/" + type.ToString().ToLower() + "_";
                        r.Insert(m);
                        r.Save();
                    }
                }
            }
            return medicines;
        }



        public override List<AHref> Crawl(string url, Encoding encoding)
        {
            base.Crawl(url, encoding);
            List<AHref> l = Crawl(url, encoding, MedicineType.Medicament);
            return l;
        }

        private List<AHref> Crawl(string url, Encoding encoding, MedicineType type)
        {
            string ulClass = "NomMedicListe";
            if (type == MedicineType.Para) ulClass = "NomParaListe";
            else if (type == MedicineType.Phyto) ulClass = "ingrcpltalim";
            List<AHref> l = new List<AHref>();
            HtmlDocument doc = Load(url, encoding);
            HtmlNode ul = doc.DocumentNode.SelectSingleNode("//ul[@class=\""+ulClass+"\"]");
            if (ul != null)
            {
                foreach (HtmlNode n in ul.SelectNodes(".//li//a[@href]"))
                {
                    AHref a = new AHref();
                    a.HRef = n.GetAttributeValue("href", "").Trim();
                    a.Content = n.InnerText.Trim();
                    Console.WriteLine(a.Content);
                    if (a.HRef != "")
                        l.Add(a);
                }
            }
            return l;
        }
        

        
    }
}
