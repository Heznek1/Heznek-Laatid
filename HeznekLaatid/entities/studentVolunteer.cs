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
    
    public partial class studentVolunteer
    {
        public string id { get; set; }
        public int scholarshipSn { get; set; }
        public System.DateTime dateOfVolunteer { get; set; }
        public System.DateTime startHour { get; set; }
        public System.DateTime finishHour { get; set; }
        public string semester { get; set; }
    
        public virtual scholarship scholarship { get; set; }
        public virtual userTbl userTbl { get; set; }
    }
}
