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
    
    public partial class product
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public Nullable<int> categoryID { get; set; }
        public Nullable<System.DateTime> publicTime { get; set; }
        public Nullable<int> readCount { get; set; }
        public string contentText { get; set; }
        public string mainPhoto { get; set; }
    
        public virtual productCategory productCategory { get; set; }
    }
}