using Social.RepositoriesLibrary.Entities.Crawler;
using Social.ServicesLibrary.Crawlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.PreviewConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PreviewCrawler c = new PreviewCrawler();
            string url = "http://www.cyrilvincent.com";
            Console.WriteLine(url);
            Preview p = c.Crawl(url);
            Console.WriteLine(p);
            url = "http://www.youtube.com";
            Console.WriteLine(url);
            p = c.Crawl(url);
            Console.WriteLine(p);
            url = "https://www.youtube.com/watch?v=kp59t0fcjCY";
            Console.WriteLine(url);
            p = c.Crawl(url);
            Console.WriteLine(p);
            url = "http://www.dailymotion.com/video/x1uw9dd_rama-yade-tres-surprise-en-voyant-son-mari-a-la-tele_news";
            Console.WriteLine(url);
            p = c.Crawl(url);
            Console.WriteLine(p);
            url = "http://www.the120site.com";
            Console.WriteLine(url);
            p = c.Crawl(url);
            Console.WriteLine(p);
            url = "http://the120site.com/html/medicaments/medicament_A-GRAM.htm";
            Console.WriteLine(url);
            p = c.Crawl(url);
            Console.WriteLine(p);
            Console.ReadKey();
        }
    }
}
