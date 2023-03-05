using EdwillLoanAppMVC4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpDevelopMVC4.ViewModels
{
    public class CustomerViewModel
    {
        public DepositAccount DepositAccount { get; set; }
        public List <Customer> CustomersLookUp{ get; set; }

    }
}