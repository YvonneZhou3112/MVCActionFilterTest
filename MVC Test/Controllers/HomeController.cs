using MVC_Test.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Test.Controllers
{
    [HandleException]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = $"This is the time {DateTime.Now.ToString()}";
            return View();
        }
        [OutputCache(Duration =10)]
        public ActionResult Hello(int? id) {
            ViewBag.Message = $"This is the time {DateTime.Now.ToString()}";
            return View();
        }

        

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

        public ActionResult FeatureForRebase() { 
            return View();
        }
        
        public ActionResult Remote()
        {
            ViewBag.Message = "Your remote page.";

            return View();
        }

        public ActionResult VS2022()
        {
            ViewBag.Message = "Your Visual Studio 2022 page.";

            return View();
        }

        public ActionResult VS2022SyncTest2()
        {
            ViewBag.Message = "Your Visual Studio 2022 Sync page.";

            return View();
        }

        public ActionResult AzurePipelineTrigger3()
        {
            ViewBag.Message = "Your Azure Pipeline commit page.";

            return View();
        }
    }
}
