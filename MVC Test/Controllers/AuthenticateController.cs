using MVC_Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Test.Controllers
{
    public class AuthenticateController : Controller
    {
        public ActionResult Login(string returnUrl) 
        { 
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Username, string Role, string ReturnUrl) {
            if (string.IsNullOrEmpty(Username))
                Username = string.Empty;

            // authentication code here


            string token= JWT.GenerateToken(Username, Role);

            var authTicket = new FormsAuthenticationTicket(1, Username, DateTime.Now, DateTime.Now.AddMinutes(30), true, token);
            string cookieContents = FormsAuthentication.Encrypt(authTicket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
            {
                Expires = authTicket.Expiration,
                Path = FormsAuthentication.FormsCookiePath
            };

            Response.Cookies.Add(cookie);
            return RedirectToAction("Index", "Movies");
        }

       
        
        [HttpPost]
        public ActionResult Login2(string Username, string Role, string ReturnUrl)
        {
            if(string.IsNullOrEmpty(Username))
                Username= string.Empty;

            var authTicket = new FormsAuthenticationTicket(1, Username, DateTime.Now, DateTime.Now.AddMinutes(30), true, Role);
            string cookieContents = FormsAuthentication.Encrypt(authTicket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
            {
                Expires = authTicket.Expiration,
                Path = FormsAuthentication.FormsCookiePath
            };

            Response.Cookies.Add(cookie);

            if (!string.IsNullOrEmpty(ReturnUrl))
                return Redirect(ReturnUrl);
           
            return RedirectToAction("Index","Movies");
        }
    }
}