using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Final_Restaurant_Management_System_RMS.Models;

namespace Final_Restaurant_Management_System_RMS.Controllers
{
    public class Delete_Staff_RegistrationController : Controller
    {
        //
        // GET: /Delete_Staff_Registration/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAllStaff_List()
        {
            return View(new Delete_Staff_Info().GetAllStaffList());
        }
	}
}