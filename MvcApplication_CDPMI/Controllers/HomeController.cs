using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MvcApplication_CDPMI.Models;
using System.Data;

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
        public ActionResult Product(int id = 0)
        {
            //要使用include，必须包含using System.Data.Entity;
            //这里使用视图特定模型来传递数据
            List<product> p;
            string h2;
            //如果categoryid不存在，说明查询的是所有产品
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
        public ActionResult ProductDetails(int? id)
        {
            product p;
            if (id == null)
            {
                return HttpNotFound();
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
            basicSetting bs = db.basicSetting.First();
            return PartialView(bs);
        }
        public ActionResult FeedBack()
        {
            ViewBag.Title = "在线留言";
            return View();
        }
        /// <summary>
        /// 这个动作用来收集客户反馈
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult FeedBack(feedback fb)
        {
            //存储已经没有问题，但是验证问题还很严重，必须重新学习这一部分的内容?????
            //2014.10.23日已经基本解决
            if (ModelState.IsValid)
            {
                fb.createTime = DateTime.Now;
                db.feedback.Add(fb);
                db.SaveChanges();
                return View("FeedBackSuccess");
            }
            ViewBag.Title = "在线留言";
            return View(fb);
        }
        public ActionResult About(int id = 0)
        {
            switch (id)
            {
                case 1:
                    ViewBag.Title = "关于我们";
                    break;
                case 2:
                    ViewBag.Title = "技术专家";
                    break;
                case 3:
                    ViewBag.Title = "荣誉资质";
                    break;
                case 4:
                    ViewBag.Title = "发展历程";
                    break;
                case 5:
                    ViewBag.Title = "主要产品";
                    break;
                default:
                    return HttpNotFound();
            }

            //读取公司简介信息，用于About页面
            ViewBag.About = db.basicSetting.Find(id).BriefIntrodction;
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        /// <summary>
        /// 服务项目显示
        /// </summary>
        /// <returns></returns>
        public ActionResult Service()
        {
            ViewBag.Title = "服务项目";
            List<service> services = db.service.ToList();
            return View(services);
        }
        /// <summary>
        /// 行业动态信息显示
        /// </summary>
        /// <returns></returns>
        public ActionResult News()
        {
            ViewBag.Title = "行业动态";
            //新闻按照发布日期排序
            List<news> news = db.news.OrderByDescending(o => o.publishTime).ToList();
            return View(news);
        }
        /// <summary>
        /// 新闻详细内容显示
        /// </summary>
        /// <param name="id">NewsId</param>
        /// <returns></returns>
        public ActionResult NewsDetails(int id = 0)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            ViewBag.Title = "新闻内容";
            news news = db.news.Find(id);
            //给该条新闻的阅读次数添加1,并保存到数据库
            news.readCount += 1;
            db.Entry(news).State = EntityState.Modified;
            db.SaveChanges();
            return View(news);
        }
    }
}
