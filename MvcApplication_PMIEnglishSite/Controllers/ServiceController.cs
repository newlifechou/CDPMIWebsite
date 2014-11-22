using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication_PMIEnglishSite.Models;

namespace MvcApplication_PMIEnglishSite.Controllers
{
    public class ServiceController : Controller
    {
        private pmienglish db = new pmienglish();

        //
        // GET: /Service/
        [Authorize]
        public ActionResult Index()
        {
            return View(db.service_en.ToList());
        }

        //
        // GET: /Service/Details/5

        //public ActionResult Details(int id = 0)
        //{
        //    service_en service_en = db.service_en.Find(id);
        //    if (service_en == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(service_en);
        //}

        //
        // GET: /Service/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Service/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize]
        public ActionResult Create(service_en service_en)
        {
            if (ModelState.IsValid)
            {
                db.service_en.Add(service_en);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(service_en);
        }

        //
        // GET: /Service/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            service_en service_en = db.service_en.Find(id);
            if (service_en == null)
            {
                return HttpNotFound();
            }
            return View(service_en);
        }

        //
        // POST: /Service/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [ValidateInput(false)]
        public ActionResult Edit(service_en service_en)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service_en).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service_en);
        }

        //
        // GET: /Service/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            service_en service_en = db.service_en.Find(id);
            if (service_en == null)
            {
                return HttpNotFound();
            }
            return View(service_en);
        }

        //
        // POST: /Service/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        [ValidateInput(false)]
        public ActionResult DeleteConfirmed(int id)
        {
            service_en service_en = db.service_en.Find(id);
            db.service_en.Remove(service_en);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}