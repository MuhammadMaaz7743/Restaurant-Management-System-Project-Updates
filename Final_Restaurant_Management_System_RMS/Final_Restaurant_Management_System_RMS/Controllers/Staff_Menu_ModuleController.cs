using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Final_Restaurant_Management_System_RMS.Models;

namespace Final_Restaurant_Management_System_RMS.Controllers
{
    public class Staff_Menu_ModuleController : Controller
    {
        //
        // GET: /Menu_Module/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult InsertMenu_Module()
        {
            return View(new Staff_Menu_Module());
        }
        [HttpPost]
        public ActionResult InsertMenu_Module(Staff_Menu_Module c1)
        {
            Staff_Menu_Module c2 = new Staff_Menu_Module();
            if (ModelState.IsValid)
            {
                c2.AddMenu_Module(c1);
                ModelState.Clear();
                string msg = "New Data Added Successfully ... ";
                ViewBag.Message = msg;
                return RedirectToAction("GetAllMenu_Module_List", "Staff_Menu_Module");
            }
            return View();
        }
        [HttpGet]
        public ActionResult GetAllMenu_Module_List()
        {
            return View(new Staff_Menu_Module().GetAllMenu_ModuleList());
        }

        [HttpGet]
        public ActionResult GetAllMenu_Module_ListBYIDs(int C_ID)
        {
            Staff_Menu_Module DL1 = new Staff_Menu_Module();
            Staff_Menu_Module DL2 = DL1.GetMenu_Module_ListByID(C_ID);
            return View(DL2);

        }

        [HttpGet]
        public ActionResult UpdateAllMenu_Module_ListBYIDs(int C_ID)
        {
            // return View(new Deal_List());
            Staff_Menu_Module DL1 = new Staff_Menu_Module();
            Staff_Menu_Module DL2 = DL1.GetMenu_Module_ListByID(C_ID);
            return View(DL2);
        }
        [HttpPost]
        public ActionResult UpdateAllMenu_Module_ListBYIDs(Staff_Menu_Module Menu_Module)
        {
            Staff_Menu_Module DL = new Staff_Menu_Module();
            if (ModelState.IsValid)
            {
                DL.UpdateMenu_Module_List(Menu_Module);
                ModelState.Clear();
                return RedirectToAction("GetAllMenu_Module_List", "Staff_Menu_Module");
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
        public ActionResult DeleteAllMenu_Module_ListBYIDs(int C_ID)
        {
            Staff_Menu_Module DL1 = new Staff_Menu_Module();
            Staff_Menu_Module DL2 = DL1.GetMenu_Module_ListByID(C_ID);
            return View(DL2);
        }
        [HttpPost]
        public ActionResult DeleteAllMenu_Module_ListBYIDs(Staff_Menu_Module Menu_Module)
        {
            Staff_Menu_Module DL = new Staff_Menu_Module();
            if (ModelState.IsValid)
            {
                DL.DeleteMenu_Module_List(Menu_Module);
                ModelState.Clear();
                return RedirectToAction("GetAllMenu_Module_List", "Staff_Menu_Module");
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