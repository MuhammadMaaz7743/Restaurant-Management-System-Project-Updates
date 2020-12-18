using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Final_Restaurant_Management_System_RMS.Models;

namespace Final_Restaurant_Management_System_RMS.Controllers
{
    public class Menu_ModuleController : Controller
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
            return View(new Menu_Module());
        }
        [HttpPost]
        public ActionResult InsertMenu_Module(Menu_Module c1)
        {
            Menu_Module c2 = new Menu_Module();
            if (ModelState.IsValid)
            {
                c2.AddMenu_Module(c1);
                ModelState.Clear();
                string msg = "New Data Added Successfully ... ";
                ViewBag.Message = msg;
                return RedirectToAction("GetAllMenu_Module_List", "Menu_Module");
            }
            return View();
        }
        [HttpGet]
        public ActionResult GetAllMenu_Module_List()
        {
            return View(new Menu_Module().GetAllMenu_ModuleList());
        }

        [HttpGet]
        public ActionResult GetAllMenu_Module_ListBYIDs(int C_ID)
        {
            Menu_Module DL1 = new Menu_Module();
            Menu_Module DL2 = DL1.GetMenu_Module_ListByID(C_ID);
            return View(DL2);

        }

        [HttpGet]
        public ActionResult UpdateAllMenu_Module_ListBYIDs(int C_ID)
        {
            // return View(new Deal_List());
            Menu_Module DL1 = new Menu_Module();
            Menu_Module DL2 = DL1.GetMenu_Module_ListByID(C_ID);
            return View(DL2);
        }
        [HttpPost]
        public ActionResult UpdateAllMenu_Module_ListBYIDs(Menu_Module Menu_Module)
        {
            Menu_Module DL = new Menu_Module();
            if (ModelState.IsValid)
            {
                DL.UpdateMenu_Module_List(Menu_Module);
                ModelState.Clear();
                return RedirectToAction("GetAllMenu_Module_List", "Menu_Module");
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
            Menu_Module DL1 = new Menu_Module();
            Menu_Module DL2 = DL1.GetMenu_Module_ListByID(C_ID);
            return View(DL2);
        }
        [HttpPost]
        public ActionResult DeleteAllMenu_Module_ListBYIDs(Menu_Module Menu_Module)
        {
            Menu_Module DL = new Menu_Module();
            if (ModelState.IsValid)
            {
                DL.DeleteMenu_Module_List(Menu_Module);
                ModelState.Clear();
                return RedirectToAction("GetAllMenu_Module_List", "Menu_Module");
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