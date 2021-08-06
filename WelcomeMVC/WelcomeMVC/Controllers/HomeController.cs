using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace WelcomeMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Welcome()
        {
            return View();
        }
        public ActionResult Welcome1()
        {
            return View();
        }

        public ActionResult Welcome2()
        {
            
            String _name = Request.QueryString["developer"];
            String _nameString = "";
            for(int i = 0; i < 10; i++)
            {
                _nameString += _name + "<br>";
            }
            var content = Content(_nameString); 
            return content;
        }
        public ActionResult Welcome3()
        {
            String _developerName = Request.QueryString["developer"];
            
            if (_developerName == null)
            {
                var onLoadData = new
                {
                    Name = "Vaibhav",
                    Company = "AurionPro"
                };
                return Json(onLoadData, JsonRequestBehavior.AllowGet);
            }
            var afterQStringInputData = new
            {
                Name = _developerName,
                Company = "AurionPro"
            };
            
            return Json(afterQStringInputData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Form()
        {
            
            return View();
        }
        public ActionResult Auth()
        {

            return View();
        }

    }
}