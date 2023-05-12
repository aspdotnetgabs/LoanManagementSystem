using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VisualStudioMVC4.Models
{
    public class SdMvc4DbContext : DbContext
    {
        public SdMvc4DbContext() : base("SdMvcLocalDb") // name_of_dbconnection_string
        {
        }

        // Map model classes to database tables
        public DbSet<UserAccount> Users { get; set; }
        
        public DbSet<Product> Products { get; set; }
        
    }


}

