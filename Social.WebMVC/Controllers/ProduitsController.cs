using Social.RepositoriesLibrary.Entities.Crawler;
using Social.RepositoriesLibrary.Repositories.Files;
using Social.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Social.WebMVC.Controllers
{
    public class ProduitsController : Controller
    {
        //
        // GET: /Produit/
        public ActionResult Index()
        {
            SearchVM<Medicine> vm = new SearchVM<Medicine>();
            MedicineFileRepository r = new MedicineFileRepository { Path = Server.MapPath("~/html/products") };
            r.Load();
            vm.Results = r.GetAll().Take(50).ToList();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Text,Type")] SearchVM<Medicine> vm)
        {
            // A remplacer par service
            MedicineFileRepository r = new MedicineFileRepository { Path = Server.MapPath("~/html/products") };
            r.Load();
            if (vm.Text == null)
                if (vm.Type == MedicineTypeVM.All)
                    vm.Results = r.GetAll();
                else
                    vm.Results = r.GetByType(vm.GetMedicineType());
            else
                if (vm.Type == MedicineTypeVM.All)
                    vm.Results = r.GetByName(vm.Text);
                else
                    vm.Results = r.GetByTypeAndName(vm.GetMedicineType(), vm.Text);
            vm.Results = vm.Results.Take(50).ToList();
            return View(vm);
        }

        public ActionResult Details(string name)
        {
            MedicineFileRepository r = new MedicineFileRepository { Path = Server.MapPath("~/html/products/") };
            r.Load();
            Medicine m = r.GetByFileName(name);
            return View(m);
        }

        public ActionResult Reset()
        {
            SearchVM<Medicine> vm = new SearchVM<Medicine>();
            MedicineFileRepository r = new MedicineFileRepository { Path = Server.MapPath("~/html/products") };
            r.Reset();
            return RedirectToAction("Index");
        }
	}
}