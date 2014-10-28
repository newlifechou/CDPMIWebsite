using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication_CDPMI.Controllers
{
    public class AdminController : Controller
    {
        /// <summary>
        /// 显示管理编辑界面的欢迎界面
        /// 添加有身份验证要求的Attribute
        /// </summary>
        /// <returns></returns>
        // GET: /Admin/

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}
