using System;
using System.Collections;
using System.Collections.Generic;

namespace PayrollAPI.Models
{
    public class PayrollHistory
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string PayrollType { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public virtual PayoutHistory PayoutHistory { get; set; }
        public int? PayoutHistoryId { get; set; } 
        public string PayoutHistoryUniqueCode { get; set; } 
         public Company Company { get; set; }
        public int CompanyId { get; set; }
       
    }
}