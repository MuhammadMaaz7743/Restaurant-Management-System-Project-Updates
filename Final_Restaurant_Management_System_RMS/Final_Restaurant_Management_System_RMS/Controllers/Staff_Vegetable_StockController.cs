using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Final_Restaurant_Management_System_RMS.Models;

namespace Final_Restaurant_Management_System_RMS.Controllers
{
    public class Staff_Vegetable_StockController : Controller
    {
        //
        // GET: /Vegetable_Stock/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult InsertVegetable_Stock()
        {
            return View(new Staff_Vegetable_Stock());
        }
        [HttpPost]
        public ActionResult InsertVegetable_Stock(Staff_Vegetable_Stock c1)
        {
            Staff_Vegetable_Stock c2 = new Staff_Vegetable_Stock();
            if (ModelState.IsValid)
            {
                c2.AddVegetable(c1);
                ModelState.Clear();
                string msg = "New Data Added Successfully ... ";
                ViewBag.Message = msg;
                return RedirectToAction("GetAllVegetable_Stock_List", "Staff_Vegetable_Stock");
            }
            return View();
        }
        [HttpGet]
        public ActionResult GetAllVegetable_Stock_List()
        {
            return View(new Staff_Vegetable_Stock().GetAllVegetable_StockList());
        }

        [HttpGet]
        public ActionResult GetAllVegetable_Stock_ListBYIDs(int C_ID)
        {
            Staff_Vegetable_Stock DL1 = new Staff_Vegetable_Stock();
            Staff_Vegetable_Stock DL2 = DL1.GetVegetable_Stock_ListByID(C_ID);
            return View(DL2);

        }

        [HttpGet]
        public ActionResult UpdateAllVegetable_Stock_ListBYIDs(int C_ID)
        {
            // return View(new Deal_List());
            Staff_Vegetable_Stock DL1 = new Staff_Vegetable_Stock();
            Staff_Vegetable_Stock DL2 = DL1.GetVegetable_Stock_ListByID(C_ID);
            return View(DL2);
        }
        [HttpPost]
        public ActionResult UpdateAllVegetable_Stock_ListBYIDs(Staff_Vegetable_Stock vegetablestock)
        {
            Staff_Vegetable_Stock DL = new Staff_Vegetable_Stock();
            if (ModelState.IsValid)
            {
                DL.UpdateVegetable_Stock_List(vegetablestock);
                ModelState.Clear();
                return RedirectToAction("GetAllVegetable_Stock_List", "Staff_Vegetable_Stock");
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
        public ActionResult DeleteAllVegetable_Stock_ListBYIDs(int C_ID)
        {
            Staff_Vegetable_Stock DL1 = new Staff_Vegetable_Stock();
            Staff_Vegetable_Stock DL2 = DL1.GetVegetable_Stock_ListByID(C_ID);
            return View(DL2);
        }
        [HttpPost]
        public ActionResult DeleteAllVegetable_Stock_ListBYIDs(Staff_Vegetable_Stock vegetablestock)
        {
            Staff_Vegetable_Stock DL = new Staff_Vegetable_Stock();
            if (ModelState.IsValid)
            {
                DL.DeleteVegetable_Stock_List(vegetablestock);
                ModelState.Clear();
                return RedirectToAction("GetAllVegetable_Stock_List", "Staff_Vegetable_Stock");
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