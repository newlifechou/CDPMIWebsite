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

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
