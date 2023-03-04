using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EdwillLoanAppMVC4.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [ForeignKey("DepositAccount")]
        public int DepositAccountId { get; set; }
        public virtual DepositAccount DepositAccount { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Amount { get; set; }

        [StringLength(30)]
        public string Notes { get; set; }

        public bool IsDeposit { get; set; } // True for Deposit, False for Withdrawal
    }
}