using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication_PMIEnglishSite.Models
{
    /// <summary>
    /// 用户验证类
    /// </summary>
    public class UserRepository
    {
        pmienglish db = new pmienglish();
        public bool ValidateUser(string userName,string passWord)
        {
            return db.admin_en.Any(u => u.userName == userName && u.passWord == passWord);
        }
    }
}