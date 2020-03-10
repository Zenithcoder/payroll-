using System;
using System.ComponentModel.DataAnnotations;

namespace PayrollAPI.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify a password between 4 and 8 characters")]
        public string Password { get; set; }

        public string City { get; set; }

        [Required]
        public string Email { get; set; }
         
        public string Country { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        
     public UserForRegisterDto()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }
 
    }
}