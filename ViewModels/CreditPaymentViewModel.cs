using SharpDevelopMVC4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpDevelopMVC4.ViewModels
{
    public class CreditPaymentViewModel
    {
        public Credit Credit { get; set; }
        public Payment Payment { get; set; }
        public List<Payment> Payments { get; set; }
        public double TotalPayment { get; set; }
        public double Balance { get; set; }
    }
}