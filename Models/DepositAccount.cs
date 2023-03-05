using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EdwillLoanAppMVC4.Models
{
    public class DepositAccount
    {
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        public string AccountNumber { get; set; }        

        public virtual List<Transaction> Transactions { get; set; }

        [NotMapped]
        public decimal Balance { get; set; }
    }
}