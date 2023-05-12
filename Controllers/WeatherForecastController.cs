using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VisualStudioMVC4.Models;

namespace VisualStudioMVC4.Controllers
{
    public class WeatherForecastController : Controller
    {
        private static readonly string[] Summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        // GET: WeatherForecast
        [HttpGet]
        public ActionResult Get(int maxItem = 5)
        {
            var random = new Random();
            var forecasts = Enumerable.Range(1, maxItem).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index).Date.ToString("dd/MM/yyyy"),
                TemperatureC = random.Next(-20, 55),
                Summary = Summaries[random.Next(Summaries.Length)]
            });

            return Json(forecasts, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}