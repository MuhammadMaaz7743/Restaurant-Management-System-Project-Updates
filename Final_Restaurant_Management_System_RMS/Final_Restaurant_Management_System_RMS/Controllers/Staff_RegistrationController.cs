using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Final_Restaurant_Management_System_RMS.Models;

namespace Final_Restaurant_Management_System_RMS.Controllers
{
    public class Staff_RegistrationController : Controller
    {
        //
        // GET: /Staff_Registration/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult InsertStaff()
        {
            return View(new Staff_Registration());
        }
        [HttpPost]
        public ActionResult InsertStaff(Staff_Registration c1)
        {
            Staff_Registration c2 = new Staff_Registration();
            if (ModelState.IsValid)
            {
                c2.AddStaff(c1);
                ModelState.Clear();
                string msg = "New Data Added Successfully ... ";
                ViewBag.Message = msg;
                return RedirectToAction("GetAllStaff_List", "Staff_Registration");
            }
            return View();
        }
        [HttpGet]
        public ActionResult GetAllStaff_List()
        {
            return View(new Staff_Registration().GetAllStaffList());
        }

        [HttpGet]
        public ActionResult GetAllStaff_ListBYIDs(int C_ID)
        {
            Staff_Registration DL1 = new Staff_Registration();
            Staff_Registration DL2 = DL1.GetStaff_ListByID(C_ID);
            return View(DL2);

        }

        [HttpGet]
        public ActionResult UpdateAllStaff_ListBYIDs(int C_ID)
        {
            // return View(new Deal_List());
            Staff_Registration DL1 = new Staff_Registration();
            Staff_Registration DL2 = DL1.GetStaff_ListByID(C_ID);
            return View(DL2);
        }
        [HttpPost]
        public ActionResult UpdateAllStaff_ListBYIDs(Staff_Registration staff_list)
        {
            Staff_Registration DL = new Staff_Registration();
            if (ModelState.IsValid)
            {
                DL.UpdateStaff_List(staff_list);
                ModelState.Clear();
                string msg = "Data Update Successfully ... ";
                ViewBag.Message = msg;
                return RedirectToAction("GetAllStaff_List", "Staff_Registration");
            }
            else
            {
                ModelState.Clear();
                string msg = "Data Not Update Successfully ... ";
                ViewBag.Message = msg;
                return View();
            }
            // return View();
        }
        [HttpGet]
        public ActionResult DeleteAllStaff_ListBYIDs(int C_ID )
        {
            Staff_Registration DL1 = new Staff_Registration();
            Staff_Registration DL2 = DL1.GetStaff_ListByID(C_ID);
            return View(DL2);
        }
        [HttpPost]
        public ActionResult DeleteAllStaff_ListBYIDs(Staff_Registration deal_list)
        {
            Staff_Registration DL = new Staff_Registration();
            if (ModelState.IsValid)
            {
                DL.DeleteStaff_List(deal_list);
                ModelState.Clear();
                return RedirectToAction("GetAllStaff_List", "Staff_Registration");
            }
            else
            {
                ModelState.Clear();
                string msg = "Data Not Delete Successfully ... ";
                ViewBag.Message = msg;
                return View();
            }
            //return View();
        }
	}
}