using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//添加Models命名空间
using MvcApplication_PMIEnglishSite.Models;

namespace MvcApplication_PMIEnglishSite.Controllers
{
    public class HomeController : Controller
    {
        //create datacontext
        pmienglish db = new pmienglish();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //AboutPMI Data
            ViewBag.AboutPMI = db.basicSetting_en.Where(o => o.id == 1).Single().BriefIntrodction.ToString();
            return View();
        }

    }
}
