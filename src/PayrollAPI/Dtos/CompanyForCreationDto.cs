using System;
using System.Collections.Generic;
using PayrollAPI.Models;

namespace PayrollAPI.Dtos
{
    public class CompanyForCreationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }     
        public string City { get; set; }
        public string Country { get; set; }
         public string Website { get; set; }
        public int TaxIdNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public string Phone { get; set; }
        public string Industry { get; set; }
        public DateTime Created { get; set; }
       
        public int UserId { get; set; }
        
        public CompanyForCreationDto()
        {
            Created = DateTime.Now;
        }
    }
}