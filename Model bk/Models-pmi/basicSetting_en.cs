//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

namespace MvcApplication_PMIEnglishSite.Models
{
    using System;
    using System.Collections.Generic;

    public partial class basicSetting_en
    {
        public int id { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }
        [Display(Name = "Contact Person")]
        public string Contact { get; set; }
        public string BriefIntrodction { get; set; }
    }
}
