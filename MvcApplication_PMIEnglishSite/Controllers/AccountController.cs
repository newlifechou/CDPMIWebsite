using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication_PMIEnglishSite.Models;
using System.Web.Security;

namespace MvcApplication_PMIEnglishSite.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            //检测用户是否已经登录，如果是，直接转到编辑界面，如果没有，要求登录
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(admin_en admin)
        {
            if (ModelState.IsValid)
            {
                UserRepository ur = new UserRepository();
                if (ur.ValidateUser(admin.userName, admin.passWord))
                {
                    FormsAuthentication.SetAuthCookie(admin.userName, false);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "用户名或者密码不正确");
                }
            }
            return View(admin);
        }
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        /// <summary>
        /// get the current user name
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult CurrentUser()
        {
            ViewBag.CurrentUser = System.Web.HttpContext.Current.User.Identity.Name;
            return PartialView();
        }
    }
}
