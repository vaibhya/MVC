using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookieControllerApp.Controllers
{
    public class CookieController : Controller
    {
        // GET: Cookie
        public ActionResult SetCookie()
        {
            HttpCookie colorCookie = new HttpCookie("favouriteColor", "red");
            colorCookie.Expires = DateTime.Now.AddDays(7);
            Session["expire"] = colorCookie.Expires.ToString();
            Response.Cookies.Add(colorCookie);
            return View();
        }
        public ActionResult GetCookie()
        {
            HttpCookie myCookie = Request.Cookies["favouriteColor"];
            if (myCookie == null)
            {
                return Content("No Cookie found!");
            }
            
            ViewBag.Cookies = myCookie;
            return View();
            
        }
    }
}