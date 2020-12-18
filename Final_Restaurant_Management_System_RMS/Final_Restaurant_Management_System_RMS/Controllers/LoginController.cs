using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Restaurant_Management_System_RMS.Models;

namespace Final_Restaurant_Management_System_RMS.Controllers
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

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(LoginAdmin admin)
        {
            if (ModelState.IsValid)
            {
                bool Checked_User;
                Checked_User = admin.Autherize_Admin(admin.Name, admin.Password);
                if (Checked_User == true)
                {
                    return View("AdminMainPage", admin);
                }
                else
                {
                    string msg = "Invalid Username OR Password";
                    this.ViewBag.Message = msg;
                    return View();
                }

            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult StaffLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StaffLogin(LoginStaff staff)
        {
            if (ModelState.IsValid)
            {
                bool Checked_User;
                Checked_User = staff.Autherize_Staff(staff.Name, staff.Password);
                if (Checked_User == true)
                {
                    return View("StaffMainPage", staff);
                }
                else
                {
                    string msg = "Invalid Username OR Password";
                    this.ViewBag.Message = msg;
                    return View();
                }

            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult LoginGuest()
        {
            return View(new LoginGuest());
        }
        [HttpPost]
        public ActionResult LoginGuest(LoginGuest c1)
        {
            LoginGuest c2 = new LoginGuest();
            if (ModelState.IsValid)
            {
                c2.AddGuest(c1);
                ModelState.Clear();
                return RedirectToAction("GuestMainPage", "Login");
            }
            else
            {
                string msg = "Error!";
                this.ViewBag.Message = msg;
                return View();
            }
        }
        public ActionResult AdminMainPage()
        {
            return View();
        }
        public ActionResult StaffMainPage()
        {
            return View();
        }
        public ActionResult GuestMainPage()
        {
            return View();
        }
	}
}