using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SharpDevelopMVC4.Models
{
    public class SdMvc4DbContext : DbContext
    {
        public SdMvc4DbContext() : base("EdwillPhoneLoanDb") // name_of_dbconnection_string
        {
        }

        // Map model classes to database tables
        public DbSet<UserAccount> Users { get; set; }
        
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer>Customers { get; set; }
        public DbSet< Producto>Productos { get; set; }
        public DbSet<Credit>Credits { get; set; }
        public DbSet< Payment>Payments { get; set; }

    }


}

