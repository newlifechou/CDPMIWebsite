using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MvcApplication_CDPMI.Models;


namespace MvcApplication_CDPMI.Controllers
{
    public class HomeController : Controller
    {
        WebEntities db = new WebEntities();
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 在主页上显示产品信息,结合类别参数来显示
        ///  Home/Product
        /// </summary>
        /// <param name="id">CategoryId</param>
        /// <returns></returns>
        public ActionResult Product(int id=0)
        {
            //要使用include，必须包含using System.Data.Entity;
            //这里使用视图特定模型来传递数据
            List<product> p;
            string h2;
            //如果categoryid
            if (id == 0)
            {
                p = db.product.Include(o => o.productCategory).ToList();
                h2 = "全部产品信息";
            }
            else
            {
               p = db.product.Where(o => o.categoryID == id).Include(o => o.productCategory).ToList();
               h2 = db.productCategory.Where(c => c.categoryID == id).Single().categoryName;
            }
            ViewBag.h2title = h2;
            return View(p);
        }

        /// <summary>
        /// 根据具体的产品Id,返回产品详细信息
        /// </summary>
        /// <param name="id">productId</param>
        /// <returns></returns>
        public ActionResult ProductDetails(int id=0)
        {
            product p;
            if (id == 0)
            {
                return null;
            }
            else
            {
                p = db.product.Where(o => o.productID == id).Single();
            }
            return View(p);
        }

        /// <summary>
        /// 返回全部产品种类,部分视图
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllProductCategory()
        {
            List<productCategory> pc = db.productCategory.ToList();
            return PartialView(pc);
        }

        /// <summary>
        /// 返回一个包含公司练习信息的部分视图
        /// </summary>
        /// <returns></returns>
        public ActionResult GetContactsView()
        {
            //返回除了简介之外的其他内容
            List<basicSetting> bs = db.basicSetting.Where(o=>o.titleIndex<=7).OrderBy(o => o.titleIndex).ToList();
            return PartialView(bs);
        }
        /// <summary>
        /// 这个动作用来收集客户反馈
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult FeedBack()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
