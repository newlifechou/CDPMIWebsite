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
    public class ProductController : Controller
    {
        private pmienglish db = new pmienglish();

        //
        // GET: /Product/

        public ActionResult Index()
        {
            var product_en = db.product_en.Include(p => p.productCategory_en);
            return View(product_en.ToList());
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int id = 0)
        {
            product_en product_en = db.product_en.Find(id);
            if (product_en == null)
            {
                return HttpNotFound();
            }
            return View(product_en);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            ViewBag.categoryID = new SelectList(db.productCategory_en, "categoryID", "categoryName");
            return View();
        }

        //
        // POST: /Product/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(product_en product_en)
        {
            if (ModelState.IsValid)
            {
                db.product_en.Add(product_en);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryID = new SelectList(db.productCategory_en, "categoryID", "categoryName", product_en.categoryID);
            return View(product_en);
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id = 0)
        {
            product_en product_en = db.product_en.Find(id);
            if (product_en == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryID = new SelectList(db.productCategory_en, "categoryID", "categoryName", product_en.categoryID);
            return View(product_en);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(product_en product_en)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_en).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryID = new SelectList(db.productCategory_en, "categoryID", "categoryName", product_en.categoryID);
            return View(product_en);
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(int id = 0)
        {
            product_en product_en = db.product_en.Find(id);
            if (product_en == null)
            {
                return HttpNotFound();
            }
            return View(product_en);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product_en product_en = db.product_en.Find(id);
            db.product_en.Remove(product_en);
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