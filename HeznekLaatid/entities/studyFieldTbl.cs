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
    
    public partial class studyFieldTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public studyFieldTbl()
        {
            this.userTbl = new HashSet<userTbl>();
        }
    
        public int sn { get; set; }
        public string field { get; set; }
        public string nameOfDegree { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userTbl> userTbl { get; set; }
    }
}
