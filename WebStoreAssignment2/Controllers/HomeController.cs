using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStoreAssignment2.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Home")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Description")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Route("ContactInfo")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}