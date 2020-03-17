using System;
using System.Collections.Generic;
using PayrollAPI.Models;

namespace PayrollAPI.Dtos
{
    public class EmployeeForCreationDto
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

        public string Year { get; set; }
        public DateTime ResumptionDate { get; set; }
         public DateTime Created { get; set; }
        public int CompanyId { get; set; }
        
         public ICollection<ECompDeductForCreationDto> ECompDeducts { get; set; }
        public EmployeeForCreationDto()
        {
            Created = DateTime.Now;
        }
    }
}