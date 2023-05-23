using SharpDevelopMVC4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpDevelopMVC4.ViewModels
{
    public class CreditAddEditViewModel
    {
        public Credit Credit { get; set; }
        public List<Customer> CustomersLookup { get; set; }
        public List<Producto> ProductsLookup { get; set; }

    }
}