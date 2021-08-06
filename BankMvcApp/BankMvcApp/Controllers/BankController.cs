using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankMvcApp.Models.ViewModel;
using BankMvcApp.Models.Service;

namespace BankMvcApp.Controllers
{
    public class BankController : Controller
    {
        
        public ActionResult Login()
        {
            return View(new LoginVm());
        }
        [HttpPost]
        public ActionResult Login(LoginVm lVm) 
        {
            if (!this.ModelState.IsValid)
            {
                return View(lVm);
            }
            
            UserAuthetication user = new UserAuthetication(lVm.Username, lVm.Password);
            if (user.Authenticate())
            {
                Session["username"] = lVm.Username;
                Session["password"] = lVm.Password;
                return Redirect("Home");
            }
            lVm.FailMessage = "Invalid Username or password!";
            return View(lVm);
        }
        public ActionResult Home()
        {
            String username = Session["username"].ToString();
            String password = Session["password"].ToString();
            BalanceAccessService accBalance = new BalanceAccessService(username, password);
            Session["balance"] = accBalance.GetBalance();
            return View();
        }
        public ActionResult Register()
        {
            return View(new RegistrationVm());
        }
        [HttpPost]
        public ActionResult Register(RegistrationVm rVm)
        {
            if (!this.ModelState.IsValid)
            {
                return View(rVm);
            }
            UserRegistration newUser = new UserRegistration(rVm.Username, rVm.Balance, rVm.Password);
            if (newUser.RegisterUser())
            {
                rVm.SuccessMessage = "Registered Successfully!!";
                //ViewBag.message = "Registered Successfully redirecting to login page!!";
                //System.Threading.Thread.Sleep(2000);
                //return Redirect("Login");
                return View(rVm);
            }
            return Content("Something Went Wrong!");
        }

        public ActionResult Logout()
        {
            Session["username"] = null;
            Session["password"] = null;
            return Redirect("Login");
        }
    }
}