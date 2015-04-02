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

namespace Social.WebMVC.Controllers
{
    public class TestEFController : Controller
    {
        private SocialDbContext db = new SocialDbContext();

        // GET: /TestEF/
        public ActionResult Index()
        {
            return View(db.EntityMetadatas.ToList());
        }

        // GET: /TestEF/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityMetadata entitymetadata = db.EntityMetadatas.Find(id);
            if (entitymetadata == null)
            {
                return HttpNotFound();
            }
            return View(entitymetadata);
        }

        // GET: /TestEF/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TestEF/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Pseudo,ShortName,LongName,Mail,Pwd,DateTime,FName,LName,MName,Description,Text,Address1,Address2,Address3,ZipCode,City,State,Country,Phone1,Phone2,Internet,Ip,Preview")] EntityMetadata entitymetadata)
        {
            if (ModelState.IsValid)
            {
                db.EntityMetadatas.Add(entitymetadata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entitymetadata);
        }

        // GET: /TestEF/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityMetadata entitymetadata = db.EntityMetadatas.Find(id);
            if (entitymetadata == null)
            {
                return HttpNotFound();
            }
            return View(entitymetadata);
        }

        // POST: /TestEF/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Pseudo,ShortName,LongName,Mail,Pwd,DateTime,FName,LName,MName,Description,Text,Address1,Address2,Address3,ZipCode,City,State,Country,Phone1,Phone2,Internet,Ip,Preview")] EntityMetadata entitymetadata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entitymetadata).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entitymetadata);
        }

        // GET: /TestEF/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntityMetadata entitymetadata = db.EntityMetadatas.Find(id);
            if (entitymetadata == null)
            {
                return HttpNotFound();
            }
            return View(entitymetadata);
        }

        // POST: /TestEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntityMetadata entitymetadata = db.EntityMetadatas.Find(id);
            db.EntityMetadatas.Remove(entitymetadata);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
