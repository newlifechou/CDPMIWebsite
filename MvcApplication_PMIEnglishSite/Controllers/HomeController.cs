using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//添加Models命名空间
using MvcApplication_PMIEnglishSite.Models;
using System.Data;

namespace MvcApplication_PMIEnglishSite.Controllers
{
    public class HomeController : Controller
    {
        //create datacontext
        pmienglish db = new pmienglish();
        //
        // GET: /Home/
        [OutputCache(Duration = 300, Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            Response.Cache.SetOmitVaryStar(true);

            //AboutPMI Data
            ViewBag.AboutPMI = db.basicSetting_en.Find(8).BriefIntrodction;
            ViewBag.WebsiteTitle = db.basicSetting_en.Find(1).CompanyName;
            ViewBag.CompanyMission = db.basicSetting_en.Find(10).BriefIntrodction;
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
        [OutputCache(Duration = 300, VaryByParam = "id")]
        public ActionResult Product(int id = 0)
        {
            Response.Cache.SetOmitVaryStar(true);

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
            ViewBag.Title = db.productCategory_en.Find(id).categoryName;
            return View(products);
        }
        /// <summary>
        /// ProductDetails
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OutputCache(Duration = 300, VaryByParam = "id")]
        public ActionResult ProductDetails(int id = 0)
        {
            Response.Cache.SetOmitVaryStar(true);
            product_en p = db.product_en.Find(id);
            //if the p is null,that mean there is no product details in db, return not found.
            if (p == null)
            {
                return HttpNotFound();
            }
            //read count
            p.readCount++;
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();

            return View(p);
        }
        /// <summary>
        /// Serivce
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 300, VaryByParam = "id")]
        public ActionResult Service()
        {
            Response.Cache.SetOmitVaryStar(true);
            List<service_en> services = db.service_en.ToList();
            return View(services);
        }
        /// <summary>
        /// About PMI
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OutputCache(Duration = 300, VaryByParam = "id")]
        public ActionResult About(int id = 0)
        {
            Response.Cache.SetOmitVaryStar(true);
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
                    ViewBag.Title = "Management";
                    viewName = "AboutPMI";
                    break;
                //Board of Director
                case 6:
                    ViewBag.Title = "Board of Directors";
                    viewName = "AboutPMI";
                    break;
                //certificate
                case 3:
                    ViewBag.Title = "Quality Certificates";
                    viewName = "AboutPMI";
                    break;
                default:
                    break;
            }

            //general processing part
            try
            {
                ViewBag.Content = db.basicSetting_en.Find(id).BriefIntrodction;
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
        [OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult Contact()
        {
            Response.Cache.SetOmitVaryStar(true);
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
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
