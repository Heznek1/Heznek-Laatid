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
    
    public partial class @event
    {
        public int sn { get; set; }
        public string nameEvent { get; set; }
        public string subjectEvent { get; set; }
        public Nullable<System.DateTime> eventDate { get; set; }
        public Nullable<System.TimeSpan> eventHour { get; set; }
        public string eventLocation { get; set; }
        public int typeOfParticipants { get; set; }
        public Nullable<int> numParticipantsExpected { get; set; }
        public Nullable<int> numOfActualParticipants { get; set; }
        public Nullable<int> participant_sn { get; set; }
    
        public virtual statusTbl statusTbl { get; set; }
        public virtual participantInEvent participantInEvent { get; set; }
    }
}
