using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class DefectModel
    {
        public long tranx_Id { get; set; }
        public string DefectId { get; set; }
        public string EquipmentPartId { get; set; }
        public string Description { get; set; }
        public System.DateTime DateOfOccurance { get; set; }
        public string OperationStatus { get; set; }
        public Nullable<System.DateTime> InitialEstimateDateOfCompletion { get; set; }
        public Nullable<System.DateTime> RevisedEstimateDateOfCompletion { get; set; }

    }
}
