using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication_CDPMI.Models;

namespace MvcApplication_CDPMI.Controllers
{
    [Authorize]
    public class FriendLinkController : Controller
    {
        private WebEntities db = new WebEntities();

        //
        // GET: /FriendLink/

        public ActionResult Index()
        {
            return View(db.friendLink.ToList());
        }

        //
        // GET: /FriendLink/Details/5

        public ActionResult Details(int id = 0)
        {
            friendLink friendlink = db.friendLink.Find(id);
            if (friendlink == null)
            {
                return HttpNotFound();
            }
            return View(friendlink);
        }

        //
        // GET: /FriendLink/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /FriendLink/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(friendLink friendlink)
        {
            if (ModelState.IsValid)
            {
                db.friendLink.Add(friendlink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(friendlink);
        }

        //
        // GET: /FriendLink/Edit/5

        public ActionResult Edit(int id = 0)
        {
            friendLink friendlink = db.friendLink.Find(id);
            if (friendlink == null)
            {
                return HttpNotFound();
            }
            return View(friendlink);
        }

        //
        // POST: /FriendLink/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(friendLink friendlink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(friendlink).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(friendlink);
        }

        //
        // GET: /FriendLink/Delete/5

        public ActionResult Delete(int id = 0)
        {
            friendLink friendlink = db.friendLink.Find(id);
            if (friendlink == null)
            {
                return HttpNotFound();
            }
            return View(friendlink);
        }

        //
        // POST: /FriendLink/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            friendLink friendlink = db.friendLink.Find(id);
            db.friendLink.Remove(friendlink);
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