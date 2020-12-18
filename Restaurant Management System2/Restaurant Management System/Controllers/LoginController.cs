using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant_Management_System.Models;

namespace Restaurant_Management_System.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Category()
        {
            return View();
        }
        public ActionResult Admin_Login()
        {
            return View();
        }
        public ActionResult Staff_Login()
        {
            return View();
        }
        public ActionResult Main_Page()
        {
            return View();
        }
	}
}