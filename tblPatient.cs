//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NorthernLightsHospital
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblPatient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPatient()
        {
            this.tblAdmissions = new HashSet<tblAdmission>();
        }
    
        public int NAS { get; set; }
        public System.DateTime DOB { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Province { get; set; }
        public string CP { get; set; }
        public string Tel { get; set; }
        public Nullable<int> IDassurance { get; set; }
        public Nullable<int> RefParent { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAdmission> tblAdmissions { get; set; }
        public virtual tblParent tblParent { get; set; }
    }
}
