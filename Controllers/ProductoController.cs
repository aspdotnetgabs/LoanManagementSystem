using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharpDevelopMVC4.Models;

namespace SharpDevelopMVC4.Controllers
{
    public class ProductoController : Controller
    {
       SdMvc4DbContext _db = new SdMvc4DbContext();
        // GET: Product
        public ActionResult Index()
        {
            
            var product = _db.Productos.ToList();

            return View(product);
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Producto product)
        {
            
            _db.Productos.Add(product);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        
        public ActionResult Edit(int Id)
        {            
            var product = _db.Productos.Find(Id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Producto updateProduct)
        {
          
            _db.Entry(updateProduct).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int Id)
        {
           
            var prodToBeDelete = _db.Productos.Find(Id);
            _db.Productos.Remove(prodToBeDelete);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }

}