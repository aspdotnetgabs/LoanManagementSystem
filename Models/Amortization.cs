using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EdwillLoanAppMVC4.Models
{
    public class Amortization
    {
        public int Id { get; set; }

        [ForeignKey("Loan")]
        public int LoanId { get; set; }
        public virtual Loan Loan { get; set; }

        public int PeriodNo { get; set; } // aka InstallmentNumber, MonthNo: 1, 2, 3 .. 12 for 12 month term loan

        public DateTime DueDate { get; set; }     
        
        public decimal Principal { get; set; }

        public decimal Interest { get; set; }

        public decimal DueAmount { get; set; }

        public decimal Balance { get; set; }

        [NotMapped]
        public bool IsPaid { get; set; } // True if exist in Payments
    }
}