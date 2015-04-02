using Social.RepositoriesLibrary.Entities;
using Social.RepositoriesLibrary.Entities.Crawler;
using Social.RepositoriesLibrary.TransportObjects;
using Social.ServicesLibrary.Crawlers;
using Social.ServicesLibrary.Factories;
using Social.ServicesLibrary.Services;
using Social.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Social.WebMVC
{
    public class SearchController : ApiController
    {
        private MedicineService medicineService = new MedicineService(HttpContext.Current.Server.MapPath("~/html/products"));

        // GET api/<controller>
        public string Get()
        {
            return "api/Search?search=text OR api/Search?search=text&stringReturn=true";
            
        }

        // GET api/<controller>/text
        [OutputCache(Duration = 24 * 3600, VaryByParam = "search")]
        public List<Medicine> Get(string search)
        {
           return medicineService.GetByName(search, 10).ToList();
        }

        [OutputCache(Duration = 24 * 3600, VaryByParam = "search")]
        public List<Medicine> Get(string search, int take)
        {
            return medicineService.GetByName(search, take).ToList();
        }
    }
}