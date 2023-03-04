using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SharpDevelopMVC4.Models
{
    public class Loan
    {
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public decimal Amount { get; set; }

        public decimal InterestRate { get; set; } // ex: 5% per annum

        public int DurationInMonths { get; set; }

        public DateTime StartDate { get; set; } // Amortization start date

        public virtual List<Payment> Payments { get; set; }

        public virtual List<Amortization> Amortizations { get; set; }
    }
}