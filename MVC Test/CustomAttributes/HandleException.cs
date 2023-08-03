using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Test.CustomAttributes
{
    public class HandleExceptionAttribute:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //logging this exception
            Exception ex = filterContext.Exception;
            string action = filterContext.RouteData.Values["Action"] as string;
            string controller = filterContext.RouteData.Values["Controller"] as string;
            filterContext.ExceptionHandled = true;
            var model = new HandleErrorInfo(ex, controller, action);
            filterContext.Result = new ViewResult()
            {
                ViewName = "AuthenticationError",
                ViewData = new ViewDataDictionary(model)
            };
        }
    }
}