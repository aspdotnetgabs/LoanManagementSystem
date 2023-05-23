using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace SharpDevelopMVC4.Models
{
    public class Credit
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [NotMapped]
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        [NotMapped]
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime CreditDate { get; set; }
        public DateTime StartPaymentDate { get; set; } 
        public int TermInMonth { get; set; }
        public double Downpayment { get; set; }
        [NotMapped]
        public double MonthlyPayment { get; set; }
       
       
    }
}