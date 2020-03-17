using System;
using System.Collections.Generic;
using PayrollAPI.Models;

namespace PayrollAPI.Dtos
{
    public class ECompDeductForListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
         public float Value { get; set; }
        
    }
}