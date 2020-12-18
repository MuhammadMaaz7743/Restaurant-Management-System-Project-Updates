using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Final_Restaurant_Management_System_RMS.Models;

namespace Final_Restaurant_Management_System_RMS.Controllers
{
    public class Staff_Deal_ModuleController : Controller
    {
        //
        // GET: /Deal_Module/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult InsertDeal_Module()
        {
            return View(new Staff_Deal_Module());
        }
        [HttpPost]
        public ActionResult InsertDeal_Module(Staff_Deal_Module c1)
        {
            Staff_Deal_Module c2 = new Staff_Deal_Module();
            if (ModelState.IsValid)
            {
                c2.AddDeal_Module(c1);
                ModelState.Clear();
                string msg = "New Data Added Successfully ... ";
                ViewBag.Message = msg;
                return RedirectToAction("GetAllDeal_Module_List", "Staff_Deal_Module");
            }
            return View();
        }
        [HttpGet]
        public ActionResult GetAllDeal_Module_List()
        {
            return View(new Staff_Deal_Module().GetAllDeal_ModuleList());
        }

        [HttpGet]
        public ActionResult GetAllDeal_Module_ListBYIDs(int C_ID)
        {
            Staff_Deal_Module DL1 = new Staff_Deal_Module();
            Staff_Deal_Module DL2 = DL1.GetDeal_Module_ListByID(C_ID);
            return View(DL2);

        }

        [HttpGet]
        public ActionResult UpdateAllDeal_Module_ListBYIDs(int C_ID)
        {
            // return View(new Deal_List());
            Staff_Deal_Module DL1 = new Staff_Deal_Module();
            Staff_Deal_Module DL2 = DL1.GetDeal_Module_ListByID(C_ID);
            return View(DL2);
        }
        [HttpPost]
        public ActionResult UpdateAllDeal_Module_ListBYIDs(Staff_Deal_Module deal_list)
        {
            Staff_Deal_Module DL = new Staff_Deal_Module();
            if (ModelState.IsValid)
            {
                DL.UpdateDeal_Module_List(deal_list);
                ModelState.Clear();
                return RedirectToAction("GetAllDeal_Module_List", "Staff_Deal_Module");
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
        public ActionResult DeleteAllDeal_Module_ListBYIDs(int C_ID)
        {
            Staff_Deal_Module DL1 = new Staff_Deal_Module();
            Staff_Deal_Module DL2 = DL1.GetDeal_Module_ListByID(C_ID);
            return View(DL2);
        }
        [HttpPost]
        public ActionResult DeleteAllDeal_Module_ListBYIDs(Staff_Deal_Module deal_list)
        {
            Staff_Deal_Module DL = new Staff_Deal_Module();
            if (ModelState.IsValid)
            {
                DL.DeleteDeal_Module_List(deal_list);
                ModelState.Clear();
                return RedirectToAction("GetAllDeal_Module_List", "Staff_Deal_Module");
            }
            else
            {
                string msg = "Data Not Delete Successfully ... ";
                ViewBag.Message = msg;
                return View();
            }
            //return View();
        }
    }
}