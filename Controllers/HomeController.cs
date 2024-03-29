﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.OleDb;
using Dapper;
using Newtonsoft.Json;

namespace VisualStudioMVC4.Controllers
{
    public class HomeController : Controller
    {    	
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        [Authorize]
        public ActionResult ForAuthUser()
        {
        	ViewBag.Message = "Authorized user page. ";

            return View("About");
        }
        
        [Authorize(Roles="admin")]
        public ActionResult ForRoleUser()
        {
            ViewBag.Message = "Authorized ADMIN page.";

            return View("About");
        }        
                
    }
}