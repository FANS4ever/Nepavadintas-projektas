//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gear.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Discount
    {
        public int Id { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime ExpireDate { get; set; }
        public double Modifier { get; set; }
        public string Code { get; set; }
        public sbyte Hidden { get; set; }
        public int Game_Id { get; set; }
    
        public virtual Game Game { get; set; }
    }
}