using System;
using System.Collections.Generic;
using PayrollAPI.Models;

namespace PayrollAPI.Dtos
{
    public class CreditWalletForCreationDto
    {
        public int Id { get; set; }
        public string TransactionType { get; set; }
        public float Amount { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime Created { get; set; }
        public int CompanyId { get; set; }
        
        public CreditWalletForCreationDto()
        {
            Created = DateTime.Now;
        }
    }
}