using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
   public class Maintenance_masterModel
    {
        public long Tranx_Id { get; set; }
        public string MaintenanceMasterId { get; set; }
        public string EquipmentPartId { get; set; }
        public string Description { get; set; }
        public string Periodicity { get; set; }
        public bool EmergencyMaintenance { get; set; }
    }
}
