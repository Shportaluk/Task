using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todo.WebUI.Code.Managers;
using Todo.WebUI.Models;

namespace Todo.WebUI.Controllers
{
    public class SecurityController : Controller
    {
        private readonly ISecurityManager _securityManager;

        public SecurityController( ISecurityManager securityManager )
        {
            _securityManager = securityManager;
        }
        //
        // GET: /Security/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login( LoginModel security )
        {
            string id = _securityManager.Login(security.User, security.Pass);
            if ( id != null ) //////////////////////////////////// <- Id_Task
            {
                TaskController.Id_Task = id;
                return RedirectToAction( "Index", "Task" );
            }

            ViewBag.Error = "Error !!!";
            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            _securityManager.Logout();
            return RedirectToAction("Login", "Security");
        }
    }
}
