using Social.RepositoriesLibrary.Entities.Crawler;
using Social.ServicesLibrary.Crawlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Social.WebMVC
{
    public class PreviewController : ApiController
    {
        private PreviewCrawler c = new PreviewCrawler();

        // GET api/<controller>
        public string Get()
        {
            return "api/Preview POST value=url";
        }

        // POST api/<controller>
        [OutputCache(Duration=24*3600, VaryByParam="value")]
        
        public Preview Post([FromBody]string value)
        {
            PreviewCrawler c = new PreviewCrawler();
            return c.Crawl(value);
        }

    }
}