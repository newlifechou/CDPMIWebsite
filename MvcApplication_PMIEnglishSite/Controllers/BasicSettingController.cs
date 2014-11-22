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
    public class BasicSettingController : Controller
    {
        private pmienglish db = new pmienglish();

        //
        // GET: /BasicSetting/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /BasicSetting/Details/5

        //public ActionResult Details(int id = 0)
        //{
        //    basicSetting_en basicsetting_en = db.basicSetting_en.Find(id);
        //    if (basicsetting_en == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(basicsetting_en);
        //}

        //
        // GET: /BasicSetting/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        //
        // POST: /BasicSetting/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(basicSetting_en basicsetting_en)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.basicSetting_en.Add(basicsetting_en);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(basicsetting_en);
        //}

        //
        // GET: /BasicSetting/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //if the id is not in our setting range in database,return notfound
            if (id <= 0 || id >= 8)
            {
                return HttpNotFound();
            }

            basicSetting_en basicsetting_en = db.basicSetting_en.Find(id);
            if (basicsetting_en == null)
            {
                return HttpNotFound();
            }
            switch (id)
            {
                case 7:
                    ViewBag.Title = "Introduction";
                    break;
                case 3:
                    ViewBag.Title = "Certificate";
                    break;
                case 4:
                    ViewBag.Title = "History";
                    break;
                case 6:
                    ViewBag.Title = "Board of Director";
                    break;
                case 2:
                    ViewBag.Title = "Management and Technical Consultants";
                    break;
                default:
                    break;
            }
            //if it is the contact information,using a special view
            if (id == 1)
            {
                return View("ContactEdit", basicsetting_en);
            }
            else
            {
                return View(basicsetting_en);
            }
        }

        //
        // POST: /BasicSetting/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(basicSetting_en basicsetting_en)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basicsetting_en).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(basicsetting_en);
        }

        //
        // GET: /BasicSetting/Delete/5

        //public ActionResult Delete(int id = 0)
        //{
        //    basicSetting_en basicsetting_en = db.basicSetting_en.Find(id);
        //    if (basicsetting_en == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(basicsetting_en);
        //}

        ////
        //// POST: /BasicSetting/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    basicSetting_en basicsetting_en = db.basicSetting_en.Find(id);
        //    db.basicSetting_en.Remove(basicsetting_en);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}