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
    
    public partial class academicInstitutTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public academicInstitutTbl()
        {
            this.userTbl = new HashSet<userTbl>();
        }
    
        public int sn { get; set; }
        public string nameOfInstitut { get; set; }
        public Nullable<int> placeOfInstitute { get; set; }
    
        public virtual cityTbl cityTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<userTbl> userTbl { get; set; }
    }
}
