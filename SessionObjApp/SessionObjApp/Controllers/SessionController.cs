using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace SessionObjApp.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        public ActionResult Index()
        {
            if(Session["key"] == null)
            {
                Session["key"] = 0;
                
            }
            ViewBag.OldId = Session["key"];
            Session["key"] = ((int)Session["key"]) + 1;
            string sessionID = HttpContext.Session.SessionID;
            ViewBag.SessionId = sessionID;
            return View();
        }
    }
}