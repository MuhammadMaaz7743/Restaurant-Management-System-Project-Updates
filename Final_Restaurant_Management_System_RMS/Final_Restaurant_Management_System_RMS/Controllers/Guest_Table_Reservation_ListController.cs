using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Final_Restaurant_Management_System_RMS.Models;
namespace Final_Restaurant_Management_System_RMS.Controllers
{
    public class Guest_Table_Reservation_ListController : Controller
    {
        //
        // GET: /Guest_Table_Reservation_List/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllTable_ReservationList()
        {
            return View(new Guest_Table_Reservation_List().GetAllTable_ReservationList());
        }
	}
}