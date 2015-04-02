using Social.RepositoriesLibrary.Repositories.EF;
using Social.ServicesLibrary.Factories;
using Social.UnitTests;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Social.WebMVC.Controllers
{
    public class UnitTestController : Controller
    {
        private List<string> messages = new List<string>();

        //
        // GET: /UnitTest/
        public ActionResult Index()
        {
            NUnitCustomEngine test = new NUnitCustomEngine();
            test.MethodEvent += test_MethodEvent;
            messages.Add(User.Identity.Name);
            messages.Add(Server.MachineName);
            messages.Add(Environment.OSVersion.VersionString);
            messages.Add(Environment.ProcessorCount + " cores");
            messages.Add(Environment.Version.ToString());
            messages.Add(UnityHelper.Resolve<DbContext>().Database.Connection.ConnectionString);
            messages.Add(Request.Browser.Browser);
            test.Test();
            messages.Add("Result: " + test.NbSuccess + "/" + test.NbMethod);
            ViewBag.Message = messages;
            return View();
        }

        private void test_MethodEvent(System.Reflection.MethodInfo mi, string s, Exception ex)
        {
            messages.Add(s);
        }
	}
}