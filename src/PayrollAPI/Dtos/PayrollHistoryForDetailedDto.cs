using System;
using System.Collections.Generic;
using PayrollAPI.Models;

namespace PayrollAPI.Dtos
{
    public class PayrollHistoryForDetailedDto
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string PayrollType { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string PayoutHistoryUniqueCode { get; set; } 
        
        
       
    }
}