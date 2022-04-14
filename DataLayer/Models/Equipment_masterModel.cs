using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Equipment_masterModel
    {
        public long Tranx_Id { get; set; }
        public string EquipmentPartId { get; set; }
        public string Description { get; set; }        
        public string ParentEquipmentPartId { get; set; }
        public string EquipmentType { get; set; }
        public bool IsPhysical { get; set; }
        public string Compartment { get; set; }
        
    }
}

