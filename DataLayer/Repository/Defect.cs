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
    
    public partial class defect
    {
        public string DefectId { get; set; }
        public string EquipmentPartId { get; set; }
        public string Description { get; set; }
        public System.DateTime DateOfOccurance { get; set; }
        public string OperationStatus { get; set; }
        public Nullable<System.DateTime> InitialEstimateDateOfCompletion { get; set; }
        public Nullable<System.DateTime> RevisedEstimateDateOfCompletion { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedTs { get; set; }
        public string ChangedBy { get; set; }
        public Nullable<System.DateTime> ChangedTs { get; set; }
    
        public virtual equipment_master equipment_master { get; set; }
        public virtual FinancialCases FinancialCases { get; set; }
    }
}
