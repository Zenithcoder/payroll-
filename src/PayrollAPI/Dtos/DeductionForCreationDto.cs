using System;
using System.Collections.Generic;
using PayrollAPI.Models;

namespace PayrollAPI.Dtos
{
    public class DeductionForCreationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
         
        public DateTime Created { get; set; }
       
        public int CompanyId { get; set; }
        
        public DeductionForCreationDto()
        {
            Created = DateTime.Now;
        }
    }
}