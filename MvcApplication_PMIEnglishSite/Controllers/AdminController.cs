using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication_PMIEnglishSite.Controllers
{
    public class AdminController : Controller
    {
        //Admin welcome Page
        // GET: /Admin/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}
