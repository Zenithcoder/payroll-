using System;
using System.Collections;
using System.Collections.Generic;

namespace PayrollAPI.Models
{
    public class Deduction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
    }
}