//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HeznekLaatid.entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class studentScholarship
    {
        public string id { get; set; }
        public int sn { get; set; }
        public Nullable<int> amountOfGivanScholarship { get; set; }
        public Nullable<int> numOfDeposits { get; set; }
        public Nullable<int> currentYear { get; set; }
        public string wasGivenInPast { get; set; }
    
        public virtual scholarship scholarship { get; set; }
        public virtual userTbl userTbl { get; set; }
    }
}
