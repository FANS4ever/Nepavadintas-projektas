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
    
    public partial class Visit
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int Game_Id { get; set; }
        public string User_Username { get; set; }
    
        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}
