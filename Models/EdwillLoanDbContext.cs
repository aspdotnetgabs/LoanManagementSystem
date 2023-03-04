using EdwillLoanAppMVC4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EdwillLoanAppMVC4.Models
{
    public class EdwillLoanDbContext : DbContext
    {
        public EdwillLoanDbContext() : base("EdwillLoanDb") // name_of_dbconnection_string // I-rename ang _web.config kwaa ang underscore
        {
        }

        // Map model classes to database tables
        public DbSet<UserAccount> Users { get; set; }

        // Edwill Loan App Entity Models
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DepositAccount> DepositAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Amortization> Amortizations { get; set; }
        public DbSet<Payment> Payments { get; set; }

    }


}

