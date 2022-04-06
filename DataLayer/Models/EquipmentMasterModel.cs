using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class EquipmentMasterModel
    {
        public long tranx_Id { get; set; }
        public string EquipmentPartId { get; set; }
        public string Description { get; set; }        
        public string ParentEquipmentPartId { get; set; }
        public Nullable<bool> IsPhysical { get; set; }
        public string Compartment { get; set; }
        
    }
}

