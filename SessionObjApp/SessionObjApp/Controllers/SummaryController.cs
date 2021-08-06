using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionObjApp.Controllers
{
    public class SummaryController : Controller
    {
        // GET: Summary
        public ActionResult Index()
        {
            ViewBag.SessionVal = Session["key"];
            ViewBag.ApplicationVal = HttpContext.Application["key"];
            return View();
        }
    }
}