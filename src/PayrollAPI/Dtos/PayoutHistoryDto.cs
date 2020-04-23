using System;
using System.Collections.Generic;
using PayrollAPI.Models;

namespace PayrollAPI.Dtos
{
    public class PayoutHistoryDto
    {
        
        public string Description { get; set; }
        public string Action { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        
        
 
    }
}