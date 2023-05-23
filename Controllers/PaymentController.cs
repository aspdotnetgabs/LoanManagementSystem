using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharpDevelopMVC4.Models;
using SharpDevelopMVC4.ViewModels;

namespace SharpDevelopMVC4.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        SdMvc4DbContext _db = new SdMvc4DbContext();

        // GET: Payment
        public ActionResult Index(int? Id) //CreditId
        {
            if (Id == null)
            {
                return RedirectToAction("Index", "Credit");
            }

            var creditPaymentVM = new CreditPaymentViewModel();

            creditPaymentVM.Credit = _db.Credits.Find(Id);

            var customer = _db.Customers.Find(creditPaymentVM.Credit.CustomerId);
            creditPaymentVM.Credit.CustomerName = customer.Name;

            var product = _db.Productos.Find(creditPaymentVM.Credit.ProductId);
            creditPaymentVM.Credit.ProductName = product.ProductName;

            creditPaymentVM.Payments = _db.Payments.Where(x => x.CreditId == creditPaymentVM.Credit.Id).ToList();

            creditPaymentVM.TotalPayment = creditPaymentVM.Payments.Sum(t => t.PaidAmount) + creditPaymentVM.Credit.Downpayment;
            creditPaymentVM.Balance = creditPaymentVM.Payments.Sum(t => t.DueAmount) - creditPaymentVM.TotalPayment + creditPaymentVM.Credit.Downpayment; ; 

            return View(creditPaymentVM);



        }
        public ActionResult Pay(int Id)
        {
            var payment = _db.Payments.Find(Id);
            DateTime currentDate = DateTime.Now;
            var dueDate = payment.DueDate;
            

            if(currentDate > dueDate)
            {
                
                payment.Penalty = payment.DueAmount * .10;

            }
            
            return View(payment);
        }

        [HttpPost]
        public ActionResult Pay(Payment updatedPayment)
        {
            _db.Entry(updatedPayment).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            var paymentId = _db.Payments.Find(updatedPayment.CreditId).Id;
            TempData["msgAlert"] = "Successfully Paid.";
            return RedirectToAction("Index", "Payment", new { Id = paymentId });
        }
        
    

    }
}