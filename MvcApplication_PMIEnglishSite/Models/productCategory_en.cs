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

    public partial class productCategory_en
    {
        public productCategory_en()
        {
            this.product_en = new HashSet<product_en>();
        }

        public int categoryID { get; set; }
        [Required(ErrorMessage = "It cannot be null")]
        [Display(Name = "Category Name")]
        public string categoryName { get; set; }
        [Display(Name = "Memo")]
        public string memo { get; set; }
        [Display(Name = "Picture")]
        [Required(ErrorMessage = "It cannot be null")]
        public string photo { get; set; }

        public virtual ICollection<product_en> product_en { get; set; }
    }
}
