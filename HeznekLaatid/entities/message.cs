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
    
    public partial class message
    {
        public int idMessage { get; set; }
        public string idSender { get; set; }
        public string message_subject { get; set; }
        public string message_content { get; set; }
        public int send_to_group { get; set; }
    
        public virtual userTbl userTbl { get; set; }
        public virtual userTypeTbl userTypeTbl { get; set; }
    }
}