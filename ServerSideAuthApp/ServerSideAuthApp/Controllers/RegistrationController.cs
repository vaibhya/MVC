using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServerSideAuthApp.Models;

namespace ServerSideAuthApp.Controllers
{
    public class RegistrationController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new RegistrationVm());
        }
        [HttpPost]
        public ActionResult Index(RegistrationVm vm)
        {
            if (!this.ModelState.IsValid)
            {
                return View(vm);
            }
            String message = "Thank you for registration " + vm.Name;
            return Content(message);
        }
    }
}