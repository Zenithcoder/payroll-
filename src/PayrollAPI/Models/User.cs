using System;
using System.Collections;
using System.Collections.Generic;

namespace PayrollAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }     
        public string City { get; set; }
        public string Country { get; set; }
    }
}