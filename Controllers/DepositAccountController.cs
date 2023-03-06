using EdwillLoanAppMVC4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharpDevelopMVC4.Controllers
{
    public class DepositAccountController : Controller
    {
        EdwillLoanDbContext _db = new EdwillLoanDbContext();
        public ActionResult Index()
        {
            var depositAccounts = _db.DepositAccounts.ToList();
            return View(depositAccounts);
        }

        [HttpPost]
        public ActionResult Create(Guid customerId) // customerId
        {
            var depositAccount = new DepositAccount();
            depositAccount.AccountNumber = Guid.NewGuid().ToString();
            depositAccount.CustomerId = customerId;
            _db.DepositAccounts.Add(depositAccount);
            _db.SaveChanges();
            return RedirectToAction("Detail", "Customer", new { Id = depositAccount.CustomerId });
        }


    }
}