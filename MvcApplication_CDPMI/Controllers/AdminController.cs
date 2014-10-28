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
            basicSetting bs = db.basicSetting.First();
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
        public ActionResult Basic(basicSetting bs,FormCollection fc)
        {
            if (ModelState.IsValid)
            {
                bs.BriefIntrodction = fc["BriefIntrodction"].ToString();
                db.Entry(bs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Success", "Admin");
            }
            return View(bs);
        }


    }
}
