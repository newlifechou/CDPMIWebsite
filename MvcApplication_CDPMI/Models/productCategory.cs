//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication_CDPMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class productCategory
    {
        public productCategory()
        {
            this.product = new HashSet<product>();
        }
    
        public int categoryID { get; set; }
        [Display(Name = "类别名称")]
        public string categoryName { get; set; }
        [Display(Name = "备注信息")]
        public string memo { get; set; }
    
        public virtual ICollection<product> product { get; set; }
    }
}
