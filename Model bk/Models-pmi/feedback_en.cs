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
    
    public partial class feedback_en
    {
        public int id { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "It cannot be null")]
        [StringLength(50, ErrorMessage = "The length should be shorter than 50 words")]
        public string title { get; set; }
        [Display(Name = "Create Time")]
        public System.DateTime createTime { get; set; }
        [Display(Name = "MainContent")]
        [Required(ErrorMessage = "It cannot be null")]
        public string mainContent { get; set; }
        [Display(Name = "Phone")]
        [StringLength(50, ErrorMessage = "The length should be shorter than 50 words")]
        public string phone { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "It cannot be null")]
        [StringLength(50, ErrorMessage = "The length should be shorter than 50 words")]
        [RegularExpression(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "It is not a email address")]
        public string email { get; set; }
        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "It cannot be null")]
        [StringLength(50, ErrorMessage = "The length should be shorter than 50 words")]
        public string cname { get; set; }
    }
}