using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Social.RepositoriesLibrary.Entities;
using Social.RepositoriesLibrary.Repositories.EF;
using Social.RepositoriesLibrary.Entities.Crawler;
using Social.ServicesLibrary.Crawlers;

namespace Social.WebMVC.Controllers
{
    public class PreviewController : Controller
    {

        // GET: /Preview/
        public ActionResult Index()
        {
            return View(new Preview { Url = "http://the120site.com" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include="Url")] Preview p)
        {
            PreviewCrawler c = new PreviewCrawler();
            p = c.Crawl(p.Url);
            return View(p);
        }

        
    }
}
