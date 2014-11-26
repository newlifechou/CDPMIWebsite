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
            ViewBag.AboutPMI = db.basicSetting_en.Where(o => o.id == 8).Single().BriefIntrodction;
            ViewBag.WebsiteTitle = db.basicSetting_en.Where(o => o.id == 1).Single().CompanyName;
            ViewBag.CompanyMission = db.basicSetting_en.Where(o => o.id == 10).Single().BriefIntrodction;
            //List<productCategory_en> pclist = db.productCategory_en.ToList();
            //将首页所需的数据添加到一个视图对象当中，然后传递这个视图对象给视图。
            HomeIndexData hid = new HomeIndexData();
            hid.flashlist = db.flash_en.ToList();
            hid.pclist = db.productCategory_en.ToList();
            return View(hid);
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
                return View("ProductAll", query.ToList());
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
        public ActionResult ProductDetails(int id = 0)
        {
            product_en p = db.product_en.Where(o => o.productID == id).Single();
            //if the p is null,that mean there is no product details in db, return not found.
            if (p == null)
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
        /// <summary>
        /// About PMI
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult About(int id = 0)
        {
            //the follwing code needs to be simplied 
            string viewName = "";
            switch (id)
            {
                //Quality Assurance
                case 9:
                    ViewBag.Title = "Quality Assurance";
                    viewName = "QualityAssurance";
                    break;
                //About
                case 7:
                    ViewBag.Title = "About PMI";
                    viewName = "AboutPMI";
                    break;
                //History
                case 4:
                    ViewBag.Title = "PMI History";
                    viewName = "AboutPMI";
                    break;
                //Management and Technical Consultants
                case 2:
                    ViewBag.Title = "Management and Technical Consultants";
                    viewName = "AboutPMI";
                    break;
                //Board of Director
                case 6:
                    ViewBag.Title = "Board of Director";
                    viewName = "AboutPMI";
                    break;
                //certificate
                case 3:
                    ViewBag.Title = "Certificate";
                    viewName = "AboutPMI";
                    break;
                default:
                    break;
            }

            //general processing part
            try
            {
                ViewBag.Content = db.basicSetting_en.Where(o => o.id == id).Single().BriefIntrodction;
            }
            catch
            {
                return HttpNotFound();
            }

            if (viewName != "")
            {
                return View(viewName);
            }
            else
            {
                return HttpNotFound();
            }

        }
        /// <summary>
        /// Contact
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            basicSetting_en bs = db.basicSetting_en.First();
            return View(bs);
        }
        /// <summary>
        /// Feedback
        /// </summary>
        /// <returns></returns>
        public ActionResult Feedback()
        {
            ViewBag.Title = "Feedback";
            return View();
        }
        [HttpPost]
        public ActionResult Feedback(feedback_en fb)
        {
            if (ModelState.IsValid)
            {
                fb.createTime = DateTime.Now;
                db.feedback_en.Add(fb);
                db.SaveChanges();
                return View("FeedbackSuccess");
            }
            return View();
        }
    }
}
