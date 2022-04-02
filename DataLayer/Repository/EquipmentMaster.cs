//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class EquipmentMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EquipmentMaster()
        {
            this.Defect = new HashSet<Defect>();
            this.EquipmentMaster1 = new HashSet<EquipmentMaster>();
            this.PlannedMaintenance = new HashSet<PlannedMaintenance>();
        }
    
        public string EquipmentPartId { get; set; }
        public string Description { get; set; }
        public bool IsParent { get; set; }
        public string ParentEquipmentPartId { get; set; }
        public string Compartment { get; set; }
        public Nullable<bool> IsPhysical { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedTs { get; set; }
        public string ChangedBy { get; set; }
        public Nullable<System.DateTime> ChangedTs { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Defect> Defect { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipmentMaster> EquipmentMaster1 { get; set; }
        public virtual EquipmentMaster EquipmentMaster2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlannedMaintenance> PlannedMaintenance { get; set; }
    }
}
