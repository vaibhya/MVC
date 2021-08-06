using CustomerCRUDApp.Models.ViewModel;
using CustomerCRUDCoreLib.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
//using CustomerCRUDApp.Models.ViewModel;

namespace CustomerCRUDApp.Controllers
{
    public class LoginController : Controller
    {
        private ICustomerService _service;
        public LoginController(ICustomerService service)
        {
            _service = service;
        }
        // GET: Login
        
        
        public ActionResult Index()
        {
            LoginVm vm = new LoginVm();

            return View(vm);
        }
        [HttpPost]
        public ActionResult Index(LoginVm vm,string ReturnUrl)
        {
            if (!this.ModelState.IsValid)
            {
                return View(vm);
            }
            var isAuthenticate = _service.AuthenticateEmail(vm.Guid);
            if (isAuthenticate)
            {
                FormsAuthentication.SetAuthCookie(vm.Guid.ToString(), false);
                return RedirectToAction("Add","Customer");
                //return Redirect(ReturnUrl);
            }
            vm.FailMessage = "Try again!";
            return RedirectToAction("Home", "Customer");
        }
    }
}