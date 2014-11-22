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
    public class FlashController : Controller
    {
        private pmienglish db = new pmienglish();

        //
        // GET: /Flash/
        [Authorize]
        public ActionResult Index()
        {
            return View(db.flash_en.ToList());
        }

        //
        // GET: /Flash/Details/5

        //public ActionResult Details(int id = 0)
        //{
        //    flash_en flash_en = db.flash_en.Find(id);
        //    if (flash_en == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(flash_en);
        //}

        //
        // GET: /Flash/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Flash/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(flash_en flash_en)
        {
            if (ModelState.IsValid)
            {
                db.flash_en.Add(flash_en);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flash_en);
        }

        //
        // GET: /Flash/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            flash_en flash_en = db.flash_en.Find(id);
            if (flash_en == null)
            {
                return HttpNotFound();
            }
            return View(flash_en);
        }

        //
        // POST: /Flash/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(flash_en flash_en)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flash_en).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flash_en);
        }

        //
        // GET: /Flash/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            flash_en flash_en = db.flash_en.Find(id);
            if (flash_en == null)
            {
                return HttpNotFound();
            }
            return View(flash_en);
        }

        //
        // POST: /Flash/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            flash_en flash_en = db.flash_en.Find(id);
            db.flash_en.Remove(flash_en);
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