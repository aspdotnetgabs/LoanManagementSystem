﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace VisualStudioMVC4.Controllers
{
	/// <summary>
	/// Description of AccountController.
	/// </summary>
	public class AccountController : Controller
	{
		public ActionResult Login(string returnUrl = "/")
		{
			// Logout account
			FormsAuthentication.SignOut();
			// Then return login form
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}
		
		
        [AllowAnonymous]
		[HttpPost]	        
        [ValidateAntiForgeryToken]		
		public ActionResult Login(string username, string password, bool rememberme = false, string returnUrl = "/")
		{		
			var user = UserAccountCSV.Authenticate(username, password);
			if(user != null) // If not null then it's a valid login
		    {
				var authTicket = new FormsAuthenticationTicket(
				    1,                             	// version
				    user.UserName,               	// user name
				    DateTime.Now,                  	// created
				    DateTime.Now.AddMinutes(20),   	// expires
				    rememberme,                    	// persistent?
		    		user.Roles              		// can be used to store roles
			    );
				
				string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
				
				var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
				System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);
				
				Session["user"] = user.UserName;

				if (username.ToLower() == "admin" && password == "admin")
					return RedirectToAction("ChangePassword");
				else
					return Redirect(FormsAuthentication.GetRedirectUrl(user.UserName, rememberme)); // auth succeed				
		    }
		    
		    // invalid username or password
		    TempData["invalidLogin"] = "Invalid username or password";
			return RedirectToAction("Login", new { ReturnUrl = returnUrl });
		}
		
		public ActionResult Logoff()
		{
		    FormsAuthentication.SignOut();
		    return RedirectToAction("Index", "Home");
		}

		[Authorize]
		public ActionResult ChangePassword()
        {			
			return View();
        }

		[HttpPost]
		[Authorize]
		public ActionResult ChangePassword(string currentPassword, string newPassword)
		{
			bool success = UserAccountCSV.ChangePassword(User.Identity.Name, currentPassword, newPassword);
			if (success)
				TempData["alert"] = "Password changed successfully.";
			else
				TempData["alert"] = "Failed to change password.";

			return RedirectToAction("Logoff");
		}

		// Account/Register?username=user01&password="pass123"
		public ActionResult Register(string username, string password, string role = "")
		{
			if(role.ToLower() == "admin") role = "user"; // Prevent unauthorized creation of admin account			
			var result = UserAccountCSV.Create(username, password, role);
			return Content(result.UserName);
		}
		
		[Authorize(Roles="admin")]
		public ActionResult ManageUsers()
		{		
			return View();
		}
		
		[Authorize(Roles="admin")]
		[Route("/account.csv")]
		public ActionResult GetUsersCSV()
		{
			var file = UserAccountCSV.GetCsvFile();
			return File(file, "text/csv");	
		}
	}
}