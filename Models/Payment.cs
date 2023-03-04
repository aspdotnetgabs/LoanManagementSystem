using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SharpDevelopMVC4.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [ForeignKey("Loan")]
        public int LoanId { get; set; }
        public virtual Loan Loan { get; set; }

        public int PaymentFor { get; set; } // Lookup to Amortization.Id

        public decimal Amount { get; set; } // Amortization.AmountDue

        public DateTime PaymentDate { get; set; }

        public decimal LatePaymentFee { get; set; } = 0m; // Penalty

        [NotMapped]
        public decimal TotalPayment { get; set; } // Amount + LatePaymentFee
    }
}