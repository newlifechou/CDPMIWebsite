using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication_PMIEnglishSite.Models;

namespace MvcApplication_PMIEnglishSite.Models
{
    public class HomeIndexData
    {
        //slide list
        public List<flash_en> flashlist { get; set; }
        //产品种类列表
        public List<productCategory_en> pclist { get; set; }
        public string CompanyMisson { get; set; }
    }
}