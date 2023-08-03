using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Test.Controllers
{
    public class TestExceptionHandlingController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            var exp = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            //redirect to action
            //filterContext.Result= RedirectToAction("Index","Home");

            //or

            //return specific view
             filterContext.Result =  View("Exception", filterContext);

            //string action = filterContext.RouteData.Values["Action"] as string;
            //string controller = filterContext.RouteData.Values["Controller"] as string;
            //HandleErrorInfo errorInfo = new HandleErrorInfo(exp, controller,action);
            // filterContext.Result = View("Error", errorInfo);
            //or
            //filterContext.Result = new ViewResult()
            //{
            //    ViewName = "Error",
            //    ViewData = new ViewDataDictionary(errorInfo)
            //};
           

        }
        // GET: ExceptionHandling
        public ActionResult Index()
        {
            throw new Exception("Test exception");
        }
    }
}