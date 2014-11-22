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
    public class productCategoryController : Controller
    {
        private pmienglish db = new pmienglish();

        //
        // GET: /productCategory/
        [Authorize]
        public ActionResult Index()
        {         
            return View(db.productCategory_en.ToList());
        }

        //
        // GET: /productCategory/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            productCategory_en productcategory_en = db.productCategory_en.Find(id);
            if (productcategory_en == null)
            {
                return HttpNotFound();
            }
            return View(productcategory_en);
        }

        //
        // GET: /productCategory/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /productCategory/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        ///取消页面输入验证
        [ValidateInput(false)]
        public ActionResult Create(productCategory_en productcategory_en)
        {
            if (ModelState.IsValid)
            {
                db.productCategory_en.Add(productcategory_en);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productcategory_en);
        }

        //
        // GET: /productCategory/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            productCategory_en productcategory_en = db.productCategory_en.Find(id);
            if (productcategory_en == null)
            {
                return HttpNotFound();
            }
            return View(productcategory_en);
        }

        //
        // POST: /productCategory/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        ///取消页面输入验证
        [ValidateInput(false)]
        public ActionResult Edit(productCategory_en productcategory_en)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productcategory_en).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productcategory_en);
        }

        //
        // GET: /productCategory/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            productCategory_en productcategory_en = db.productCategory_en.Find(id);
            if (productcategory_en == null)
            {
                return HttpNotFound();
            }
            return View(productcategory_en);
        }

        //
        // POST: /productCategory/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        ///取消页面输入验证
        [ValidateInput(false)]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            //disable the delete function
            //productCategory_en productcategory_en = db.productCategory_en.Find(id);
            //db.productCategory_en.Remove(productcategory_en);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}