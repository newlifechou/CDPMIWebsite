using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication_CDPMI.Models;

namespace MvcApplication_CDPMI.Controllers
{
    [Authorize]
    public class FeedBackController : Controller
    {
        WebEntities db = new WebEntities();
        //
        // GET: /FeedBack/

        public ActionResult Index()
        {
            List<feedback> fbs = db.feedback.OrderByDescending(o => o.createTime).ToList();
            return View(fbs);
        }
        public ActionResult Details(int id = 0)
        {
            feedback fb = db.feedback.Find(id);
            if (fb == null)
            {
                return HttpNotFound();
            }
            return View(fb);
        }
        public ActionResult Delete(int id = 0)
        {
            feedback fb = db.feedback.Find(id);
            if (fb == null)
            {
                return HttpNotFound();
            }
            return View(fb);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            feedback fb = db.feedback.Find(id);
            db.feedback.Remove(fb);
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
