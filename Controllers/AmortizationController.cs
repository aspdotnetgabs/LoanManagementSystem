using EdwillLoanAppMVC4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EdwillLoanAppMVC4.Controllers
{
    public class AmortizationController : Controller
    {
        EdwillLoanDbContext _db = new EdwillLoanDbContext();
        public ActionResult Index()
        {

            var amortization = new Amortization();
            return View(amortization);
        }
    }
}