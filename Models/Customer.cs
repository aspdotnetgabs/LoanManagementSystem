using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SharpDevelopMVC4.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; } // to generate GUID.. customer.Id = Guid.NewGuid();

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        public virtual List<DepositAccount> DepositAccounts { get; set; }

        public virtual List<Loan> Loans { get; set; }
    }
}