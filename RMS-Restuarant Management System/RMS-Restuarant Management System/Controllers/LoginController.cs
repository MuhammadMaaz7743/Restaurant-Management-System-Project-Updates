using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RMS_Restuarant_Management_System.Models;

namespace RMS_Restuarant_Management_System.Controllers
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

        public ActionResult GuestMainPage()
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
                Checked_User = admin.Autherize_Admin(admin.Admin_ID, admin.Password);
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
        public ActionResult AdminMainPage()
        {
            return View();
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
                Checked_User = staff.Autherize_Staff(staff.Staff_ID, staff.Password);
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
        public ActionResult StaffMainPage()
        {
            return View();
        }
	}
}