using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Final_Restaurant_Management_System_RMS.Models;

namespace Final_Restaurant_Management_System_RMS.Controllers
{
    public class Staff_Order_ListController : Controller
    {
        //
        // GET: /Order_List/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult InsertOrder()
        {
            return View(new Staff_Order_List());
        }
        [HttpPost]
        public ActionResult InsertOrder(Staff_Order_List c1)
        {
            Staff_Order_List c2 = new Staff_Order_List();
            if (ModelState.IsValid)
            {
                c2.AddOrder_List(c1);
                ModelState.Clear();
                string msg = "New Data Added Successfully ... ";
                ViewBag.Message = msg;
                return RedirectToAction("GetAllOrder_List", "Staff_Order_List");
            }
            return View();
        }
        [HttpGet]
        public ActionResult GetAllOrder_List()
        {
            return View(new Staff_Order_List().GetAllOrder_List());
        }

        [HttpGet]
        public ActionResult GetAllOrder_ListBYIDs(int C_ID)
        {
            Staff_Order_List DL1 = new Staff_Order_List();
            Staff_Order_List DL2 = DL1.GetOrder_ListByID(C_ID);
            return View(DL2);

        }

        [HttpGet]
        public ActionResult UpdateAllOrder_ListBYIDs(int C_ID)
        {
            // return View(new Deal_List());
            Staff_Order_List DL1 = new Staff_Order_List();
            Staff_Order_List DL2 = DL1.GetOrder_ListByID(C_ID);
            return View(DL2);
        }
        [HttpPost]
        public ActionResult UpdateAllOrder_ListBYIDs(Staff_Order_List orderlist)
        {
            Staff_Order_List DL = new Staff_Order_List();
            if (ModelState.IsValid)
            {
                DL.UpdateOrder_List(orderlist);
                ModelState.Clear();
                return RedirectToAction("GetAllOrder_List", "Staff_Order_List");
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
    }
}