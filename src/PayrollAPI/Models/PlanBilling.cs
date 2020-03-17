using System;
using System.Collections;
using System.Collections.Generic;

namespace PayrollAPI.Models
{
    public class PlanBilling
    {
        public int Id { get; set; }
        public string Plan { get; set; }
         public string PayrollTransaction { get; set; }
          public string Fee { get; set; }
        public DateTime Created { get; set; }
       
    }
}