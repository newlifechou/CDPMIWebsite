using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication_CDPMI.Models;
using System.Data;

namespace MvcApplication_CDPMI.Controllers
{

    /// <summary>
    /// 这个控制器是严格限制访问的，必须登录才可以
    /// </summary>
    [Authorize]
    public class AdminController : Controller
    {

        WebEntities db = new WebEntities();

        /// <summary>
        /// 显示管理编辑界面的欢迎界面
        /// 添加有身份验证要求的Attribute
        /// </summary>
        /// <returns></returns>
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Success()
        {
            return View();
        }

        /// <summary>
        /// 基本信息编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Basic()
        {
            basicSetting bs = db.basicSetting.Find(1);
            return View(bs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        ///取消页面输入验证
        [ValidateInput(false)]
        public ActionResult Basic(basicSetting bs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Success", "Admin");
            }
            return View(bs);
        }

        public ActionResult OtherBasics(int id=0)
        {
            switch (id)
            {
                case 1:
                    ViewBag.Title = "关于我们";
                    break;
                case 2:
                    ViewBag.Title = "管理层&技术顾问";
                    break;
                case 3:
                    ViewBag.Title = "荣誉资质";
                    break;
                case 4:
                    ViewBag.Title = "发展历程";
                    break;
                case 5:
                    ViewBag.Title = "主要客户";
                    break;
                case 6:
                    ViewBag.Title = "董事会";
                    break;
                default:
                    return HttpNotFound();
            }
            basicSetting bs = db.basicSetting.Find(id);
            return View(bs);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult OtherBasics(basicSetting bs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Success", "Admin");
            }
            return View(bs);
        }
    }
}
