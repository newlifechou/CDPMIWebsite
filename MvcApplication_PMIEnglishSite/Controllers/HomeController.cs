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
            ViewBag.AboutPMI = db.basicSetting_en.Where(o => o.id == 1).Single().BriefIntrodction;
            ViewBag.WebsiteTitle = "Pioneer Materials Inc.";
            List<productCategory_en> pclist = db.productCategory_en.ToList();
            return View(pclist);
        }

        /// <summary>
        /// ProductListShow
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Product(int id = 0)
        {
            List<product_en> products;
            //if id=0,return the major show view
            if (id == 0)
            {
                //TODO:研究投射，改变这里的代码
                var query = from p in db.productCategory_en
                            select p;
                return View("ProductAll",query.ToList());
            }
            //如果id不等于0，那么找出对应组号的所有记录
            products = db.product_en.Where(o => o.categoryID == id).ToList();
            ViewBag.Title = db.productCategory_en.Where(o => o.categoryID == id).Single().categoryName;
            return View(products);
        }
        /// <summary>
        /// ProductDetails
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ProductDetails(int id=0)
        {
            product_en p = db.product_en.Where(o => o.productID == id).Single();
            //if the p is null,that mean there is no product details in db, return not found.
            if (p==null)
            {
                return HttpNotFound();
            }
            return View(p);
        }
        /// <summary>
        /// Serivce
        /// </summary>
        /// <returns></returns>
        public ActionResult Service()
        {
            List<service_en> services = db.service_en.ToList();
            return View(services);
        }
    }
}
