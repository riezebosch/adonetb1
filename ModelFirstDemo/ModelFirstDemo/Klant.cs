//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelFirstDemo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Klant
    {
        public Klant()
        {
            this.Products = new HashSet<Product>();
        }
    
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string Geboortedatum { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
    }
}
