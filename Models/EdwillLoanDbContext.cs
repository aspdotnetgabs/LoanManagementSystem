using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EdwillLoanAppMVC4.Models
{
    public class EdwillLoanDbContext : DbContext
    {
        public EdwillLoanDbContext() : base("EdwillLoanDb") // name_of_dbconnection_string
        {
        }

        // Map model classes to database tables
        public DbSet<UserAccount> Users { get; set; }
        
        public DbSet<Product> Products { get; set; }


        
    }


}

