//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Araba
    {
        public int arabaId { get; set; }
        public string arabaTipi { get; set; }
        public string model { get; set; }
        public string renk { get; set; }
        public int fiyat { get; set; }
        public string marka { get; set; }
        public int firmaId { get; set; }
    
        public virtual Firmalar Firmalar { get; set; }
    }
}
