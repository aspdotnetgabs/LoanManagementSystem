using EdwillLoanAppMVC4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharpDevelopMVC4.Controllers
{
    public class CustomerController : Controller
    {
        EdwillLoanDbContext _db = new EdwillLoanDbContext();
        public ActionResult Index()
        {
            var customers = _db.Customers.ToList();
            return View(customers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            customer.Id = Guid.NewGuid();
            _db.Customers.Add(customer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid Id)
        {
            var customer = _db.Customers.Find(Id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer updatedCustomer)
        {
            _db.Entry(updatedCustomer).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid Id)
        {
            var customerToBeDeleted = _db.Customers.Find(Id);
            _db.Customers.Remove(customerToBeDeleted);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}