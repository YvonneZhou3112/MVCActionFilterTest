using MVC_Test.CustomAttributes;
using MVC_Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Security;

namespace MVC_Test.Filters
{
    public class UserAuthenticateAttribute: FilterAttribute, IAuthenticationFilter, IExceptionFilter
    {

        public void OnAuthentication(AuthenticationContext context)
        {
            var controller = context.ActionDescriptor.ControllerDescriptor.ControllerName;
            var action = context.ActionDescriptor.ActionName;

            FormsIdentity identity = HttpContext.Current.User.Identity as FormsIdentity;
            if (identity != null)
            {
                FormsAuthenticationTicket ticket = identity.Ticket;
                var name = ticket.Name;
                var token = ticket.UserData;

                ClaimsPrincipal principal = JWT.ValidateToken(token) as ClaimsPrincipal;
                if (principal == null || principal.Identity.Name != name)
                    throw new Exception("Invalid user: Failed to anthenticate JWT token!");
            }
            else
            {
                context.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(
                    new { controller = "Authenticate", action = "Login", ReturnUrl = $"{controller}/{action}" }));
                //context.Result = new RedirectResult($"/Authenticate/Login?ReturnUrl={controller}/{action}");
            }
        }

       public void OnException(ExceptionContext filtercontext)
        {
            var result = new ViewResult();
            result.ViewName = "exception";
            result.ViewData = new ViewDataDictionary(filtercontext.Exception);
            filtercontext.Result = result;
            filtercontext.ExceptionHandled = true;
        }
        public void OnAuthentication2(AuthenticationContext context) 
        {
            var controller = context.ActionDescriptor.ControllerDescriptor.ControllerName;
            var action = context.ActionDescriptor.ActionName;
            var user = context.HttpContext.User;
            if (user == null || string.IsNullOrEmpty(user.Identity.Name))
                FormsAuthentication.RedirectToLoginPage($"ReturnUrl={controller}/{action}");
                    
           

        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
        }
    }
}