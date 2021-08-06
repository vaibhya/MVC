using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login1App.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult DoLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoLogin(String Username,String Password)
        {
            String details = "<h1> Your Username is " + Username + " password is " + Password;
            var webContent = Content(details);
            return webContent;
        }
    }
}