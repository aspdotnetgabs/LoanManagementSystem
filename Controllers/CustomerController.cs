using SharpDevelopMVC4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SharpDevelopMVC4.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {

        SdMvc4DbContext _db = new SdMvc4DbContext();
        // GET: Customer
        public ActionResult Index()
        {
            
            var customer = _db.Customers.ToList();

            return View(customer);
        }

        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            
            _db.Customers.Add(customer);
            _db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        
        public ActionResult Edit(int Id)
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
        public ActionResult Delete(int Id )
        {
            
            var custToBeDeleted = _db.Customers.Find(Id);
            _db.Customers.Remove(custToBeDeleted);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}