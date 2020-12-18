using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Final_Restaurant_Management_System_RMS.Models;

namespace Final_Restaurant_Management_System_RMS.Controllers
{
    public class Guest_Deal_ListController : Controller
    {
        //
        // GET: /Guest_Deal_List/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Deal_Module_List()
        {
            return View(new Guest_Deal_List().Deal_ModuleList());
        }
	}
}