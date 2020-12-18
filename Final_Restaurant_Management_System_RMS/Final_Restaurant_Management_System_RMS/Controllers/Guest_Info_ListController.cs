using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Final_Restaurant_Management_System_RMS.Models;

namespace Final_Restaurant_Management_System_RMS.Controllers
{
    public class Guest_Info_ListController : Controller
    {
        //
        // GET: /Guest_Info_List/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetAllGuest_List()
        {
            return View(new Guest_List().GetAllGuestList());
        }

	}
}