using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpDevelopMVC4.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int CreditId { get; set; }
        public DateTime DueDate { get; set; }
        public double DueAmount { get; set; }
        public double Penalty { get; set; }
        public double Interest { get; set; }
        public double MonthlyPayment { get; set; }
        public bool IsPenaltyPaid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public double PaidAmount { get; set; }
        public double Balance { get; set; }
        public string Notes { get; set; }

    }
}