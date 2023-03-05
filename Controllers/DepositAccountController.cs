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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DepositAccount depositAccount)
        {
            _db.DepositAccounts.Add(depositAccount);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}