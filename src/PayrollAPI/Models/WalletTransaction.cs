using System;
using System.Collections;
using System.Collections.Generic;

namespace PayrollAPI.Models
{
    public class WalletTransaction
    {
        public int Id { get; set; }
        public string TransactionType { get; set; }
        public string Amount { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime Created { get; set; }
       
    }
}