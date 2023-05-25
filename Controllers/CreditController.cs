using SharpDevelopMVC4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharpDevelopMVC4.ViewModels;

namespace SharpDevelopMVC4.Controllers
{
    [Authorize(Roles = "admin")]
    public class CreditController : Controller
    {
        SdMvc4DbContext _db = new SdMvc4DbContext();

        // GET: Credit
        
        public ActionResult Index()
        {
            var credits = _db.Credits.ToList();
            var customers = _db.Customers.ToList();
            var products = _db.Productos.ToList();
            var payments = _db.Payments.ToList();
            
            foreach(var credit in credits)
            {
                var thisCustomer = customers.SingleOrDefault(x => x.Id == credit.CustomerId);
                if (thisCustomer != null)
                    credit.CustomerName = thisCustomer.Name;
                else
                    continue;

                var thisProduct = products.Single(x => x.Id == credit.ProductId);
                credit.ProductName = thisProduct.ProductName;
                
                credit.MonthlyPayment = (credit.Price - credit.Downpayment) / credit.TermInMonth;

                var totalPayment = payments.Where(x => x.CreditId == credit.Id).Sum(t => t.PaidAmount);                          
               
            }

            return View(credits);
        }

        public ActionResult AddCredit()
        {
            var addCreditVM = new CreditAddEditViewModel();
            addCreditVM.CustomersLookup = _db.Customers.ToList();
            addCreditVM.ProductsLookup = _db.Productos.ToList();

            return View(addCreditVM);
        }

        [HttpPost]
        public ActionResult AddCredit(Credit credit)
        {
            //var selectedproduct = _db.Productos.Find(credit.ProductId);
            //credit.Price = selectedproduct.ProductPrice;
            _db.Credits.Add(credit);
            _db.SaveChanges();
            GenerateAmortization(credit);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            var credits = _db.Credits.Find(Id);
            return View(credits);
        }

        [HttpPost]
        public ActionResult Edit(Credit updatedCredit)
        {
            _db.Entry(updatedCredit).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int Id)
        {

            var creditToBeDeleted = _db.Credits.Find(Id);
            _db.Credits.Remove(creditToBeDeleted);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        private void GenerateAmortization(Credit credit)
        { 
            var balance = credit.Price - credit.Downpayment;
            var dueAmount = ((credit.Quantity * credit.Price) - credit.Downpayment) / credit.TermInMonth;
            for (int i = 0; i < credit.TermInMonth; i++)
            {
                var amort = new Payment();
                amort.CreditId = credit.Id;
                amort.Interest = balance * .10;
                amort.MonthlyPayment = dueAmount;
                amort.DueAmount = amort.MonthlyPayment + amort.Interest;
                amort.DueDate = credit.StartPaymentDate.AddMonths(i);
                balance -= amort.MonthlyPayment;
                amort.Balance = balance;
                _db.Payments.Add(amort);
            }

            _db.SaveChanges();
        }

        [AllowAnonymous]
        public ActionResult GetPrice(int Id)
        {
            var product = _db.Productos.Find(Id);
            var price = product.ProductPrice;
            return Json(price, JsonRequestBehavior.AllowGet);
        }


    }
}