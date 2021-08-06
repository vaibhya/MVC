using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionObjApp.Controllers
{
    public class ApplicationController : Controller
    {

        // GET: Application
        public ActionResult Index()
        {
            if (HttpContext.Application["key"] == null)
            {
                HttpContext.Application["key"] = 0;
            }
            ViewBag.PreAppCount = HttpContext.Application["key"];
            HttpContext.Application["key"]=((int)HttpContext.Application["key"]) + 1;
            ViewBag.ApplicationCount = HttpContext.Application["key"];
            return View();
        }
    }
}