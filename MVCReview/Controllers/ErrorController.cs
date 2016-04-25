using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace MVCReview.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [System.Web.Http.AllowAnonymous]
        public ActionResult Index()
        {
            var e = new Exception("Invalid Controller or/and Action Name");
            var eInfo = new HandleErrorInfo(e, "Unknown", "Unknown");
            return View("Error", eInfo);
        }
    }
}
