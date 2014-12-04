using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication_CDPMI.Controllers
{
    public class mHomeController : Controller
    {
        //
        // GET: /mHome/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /mHome/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /mHome/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /mHome/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /mHome/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /mHome/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /mHome/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /mHome/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
