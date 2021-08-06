using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login2App.Models;

namespace Login2App.Controllers
{
    public class LoginController : Controller
    {
        
        public ActionResult Index()
        {
            LoginViewModel vm = new LoginViewModel();
            vm.UserName = "username";
            vm.UserPassword = "123";
            return View(vm);
        }
        [HttpPost]
        public ActionResult Index(LoginViewModel vm)
        {
            if(vm.UserName==null || vm.UserPassword == null)
            {
                vm.ErrorMessage = "Please fill all fields!";
                return View(vm);
            }
            Session["userName"] = vm.UserName;
            Session["userPassword"] = vm.UserPassword;

            return Redirect("/Login/Welcome");
        }
        public ActionResult Welcome()
        {
            return View();
        }
    }
}