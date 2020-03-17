using System;
using System.Collections;
using System.Collections.Generic;

namespace PayrollAPI.Models
{
    public class EcompDeduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
         public float Value { get; set; }
        public string Year { get; set; }
        public DateTime Created { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
         public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}