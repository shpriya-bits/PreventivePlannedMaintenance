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
    
    public partial class FinancialCases
    {
        public string FinCaseId { get; set; }
        public string DefectId { get; set; }
        public string PlannedScheduleId { get; set; }
        public string EquipmentPartId { get; set; }
        public string Description { get; set; }
        public string BudgetaryQuote { get; set; }
        public string SanctionAmount { get; set; }
        public string DeliveryPeriod { get; set; }
        public string WorkOrder { get; set; }
        public Nullable<System.DateTime> WorkOrderDate { get; set; }
        public Nullable<System.DateTime> InitialEstimatedDateOfCompletion { get; set; }
        public Nullable<System.DateTime> RevisedEstimateDateOfCompletion { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedTs { get; set; }
        public string ChangedBy { get; set; }
        public Nullable<System.DateTime> ChangedTs { get; set; }
    
        public virtual Defect Defect { get; set; }
    }
}