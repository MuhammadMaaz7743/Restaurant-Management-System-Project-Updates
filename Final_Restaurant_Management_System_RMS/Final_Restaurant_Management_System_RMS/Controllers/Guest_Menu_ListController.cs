using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Final_Restaurant_Management_System_RMS.Models;

namespace Final_Restaurant_Management_System_RMS.Controllers
{
    public class Guest_Menu_ListController : Controller
    {
        //
        // GET: /Guest_Menu_List/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetGuestMenu_Module_List()
        {
            return View(new Guest_Menu_List().GetGuestMenu_ModuleList());
        }
	}
}