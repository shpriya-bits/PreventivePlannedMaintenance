using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class EquipmentMaster
    {
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
                
        public virtual ICollection<Defect> Defect { get; set; }
        
        public virtual ICollection<EquipmentMaster> EquipmentMaster1 { get; set; }
        public virtual EquipmentMaster EquipmentMaster2 { get; set; }
        public virtual ICollection<PlannedMaintenance> PlannedMaintenance { get; set; }
    }
}

