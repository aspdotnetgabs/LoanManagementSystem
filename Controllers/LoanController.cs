using EdwillLoanAppMVC4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EdwillLoanAppMVC4.Controllers
{
    public class LoanController : Controller
    {
        EdwillLoanDbContext _db = new EdwillLoanDbContext();
        public ActionResult Index()
        {
            var loan = _db.Loans.ToList();
            return View(loan);
        }

        [HttpPost]
        public ActionResult Create(Loan loan)
        {
            _db.Loans.Add(loan);
            _db.SaveChanges();
            GenerateAmortization(loan);
            return RedirectToAction("Detail", "Customer", new { Id = loan.CustomerId });

        }

        private void GenerateAmortization(Loan loan)
        {
            var interest = (loan.Amount /loan.DurationInMonths) * 0.05m;
            var amountDue = (loan.Amount / loan.DurationInMonths) + interest;
            
            

            for (int i = 0; i < loan.DurationInMonths; i++)
            {             
                var amort = new Amortization();
                amort.PeriodNo = loan.DurationInMonths;
                amort.Interest = interest;
                amort.LoanId = loan.Id;
                amort.DueAmount = amountDue;
                amort.DueDate = loan.StartDate.AddMonths(i);
                _db.Amortizations.Add(amort);
            }

            _db.SaveChanges();
        }
    }
}