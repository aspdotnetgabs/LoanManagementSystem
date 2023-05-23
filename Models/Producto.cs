using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpDevelopMVC4.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
    }
}