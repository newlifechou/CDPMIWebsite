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

    public partial class service_en
    {
        public int id { get; set; }
        [Required(ErrorMessage = "It cannot be null")]
        [Display(Name = "Service Name")]
        public string serviceName { get; set; }
        [Display(Name = "Service Content")]
        public string serviceContent { get; set; }
        [Display(Name = "Service Picture")]
        [Required(ErrorMessage = "It cannot be null")]
        public string servicePicture { get; set; }
    }
}
