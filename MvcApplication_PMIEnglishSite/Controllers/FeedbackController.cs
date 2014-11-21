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
    public class FeedbackController : Controller
    {
        private pmienglish db = new pmienglish();

        //
        // GET: /Feedback/

        public ActionResult Index()
        {
            return View(db.feedback_en.ToList());
        }

        //
        // GET: /Feedback/Details/5

        public ActionResult Details(int id = 0)
        {
            feedback_en feedback_en = db.feedback_en.Find(id);
            if (feedback_en == null)
            {
                return HttpNotFound();
            }
            return View(feedback_en);
        }

        //
        // GET: /Feedback/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        //
        // POST: /Feedback/Create

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ValidateInput(false)]
        //public ActionResult Create(feedback_en feedback_en)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.feedback_en.Add(feedback_en);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(feedback_en);
        //}

        //
        // GET: /Feedback/Edit/5

        //public ActionResult Edit(int id = 0)
        //{
        //    feedback_en feedback_en = db.feedback_en.Find(id);
        //    if (feedback_en == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(feedback_en);
        //}

        //
        // POST: /Feedback/Edit/5

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ValidateInput(false)]
        //public ActionResult Edit(feedback_en feedback_en)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(feedback_en).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(feedback_en);
        //}

        //
        // GET: /Feedback/Delete/5

        public ActionResult Delete(int id = 0)
        {
            feedback_en feedback_en = db.feedback_en.Find(id);
            if (feedback_en == null)
            {
                return HttpNotFound();
            }
            return View(feedback_en);
        }

        //
        // POST: /Feedback/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult DeleteConfirmed(int id)
        {
            feedback_en feedback_en = db.feedback_en.Find(id);
            db.feedback_en.Remove(feedback_en);
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