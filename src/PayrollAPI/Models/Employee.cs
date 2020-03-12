using System;
using System.Collections;
using System.Collections.Generic;

namespace PayrollAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string HomeAddress { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string JobTitle { get; set; }
        public string StaffNumber { get; set; }
        public string EmploymentLevel { get; set; }
        public DateTime ResumptionDate { get; set; }
        public DateTime Created { get; set; }
         public Company Company { get; set; }
        public int CompanyId { get; set; }
         
    }
}