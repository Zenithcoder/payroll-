using System;
using System.Collections;
using System.Collections.Generic;

namespace PayrollAPI.Models
{
    public class PayoutHistory
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string Bank { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Action { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
         public string UniqueCode { get; set; }
        public float NetPay { get; set; }
        public DateTime Created { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
       
    }
}