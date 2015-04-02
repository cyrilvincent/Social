using Social.RepositoriesLibrary;
using Social.ServicesLibrary.Crawlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.EurekaSanteCrawlerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EurekaSanteCrawler");
            Console.WriteLine("==================");
            EurekaSanteMedicineIndexCrawler crawler = new EurekaSanteMedicineIndexCrawler();
            crawler.Crawl();
            Console.ReadKey();
        }
    }
}
