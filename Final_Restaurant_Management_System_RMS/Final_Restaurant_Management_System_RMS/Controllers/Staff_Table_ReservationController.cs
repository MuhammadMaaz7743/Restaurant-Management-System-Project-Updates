﻿using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Final_Restaurant_Management_System_RMS.Models;

namespace Final_Restaurant_Management_System_RMS.Controllers
{
    public class Staff_Table_ReservationController : Controller
    {
        //
        // GET: /Table_Reservation/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult InsertTable_Reservation()
        {
            return View(new Staff_Table_Reservation());
        }
        [HttpPost]
        public ActionResult InsertTable_Reservation(Staff_Table_Reservation c1)
        {
            Staff_Table_Reservation c2 = new Staff_Table_Reservation();
            if (ModelState.IsValid)
            {
                c2.AddTable_Reservation(c1);
                ModelState.Clear();
                string msg = "New Data Added Successfully ... ";
                ViewBag.Message = msg;
                return RedirectToAction("GetAllTable_Reservation_List", "Table_Reservation");
            }
            return View();
        }
        [HttpGet]
        public ActionResult GetAllTable_Reservation_List()
        {
            return View(new Staff_Table_Reservation().GetAllTable_ReservationList());
        }

        [HttpGet]
        public ActionResult GetAllTable_Reservation_ListBYIDs(int C_ID)
        {
            Staff_Table_Reservation DL1 = new Staff_Table_Reservation();
            Staff_Table_Reservation DL2 = DL1.GetTable_Reservation_ListByID(C_ID);
            return View(DL2);

        }

        [HttpGet]
        public ActionResult UpdateAllTable_Reservation_ListBYIDs(int C_ID)
        {
            // return View(new Deal_List());
            Staff_Table_Reservation DL1 = new Staff_Table_Reservation();
            Staff_Table_Reservation DL2 = DL1.GetTable_Reservation_ListByID(C_ID);
            return View(DL2);
        }
        [HttpPost]
        public ActionResult UpdateAllTable_Reservation_ListBYIDs(Staff_Table_Reservation Table_Reservation_list)
        {
            Staff_Table_Reservation DL = new Staff_Table_Reservation();
            if (ModelState.IsValid)
            {
                DL.UpdateTable_Reservation_List(Table_Reservation_list);
                ModelState.Clear();
                return RedirectToAction("GetAllTable_Reservation_List", "Table_Reservation");
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
        public ActionResult DeleteAllTable_Reservation_ListBYIDs(int C_ID)
        {
            Staff_Table_Reservation DL1 = new Staff_Table_Reservation();
            Staff_Table_Reservation DL2 = DL1.GetTable_Reservation_ListByID(C_ID);
            return View(DL2);
        }
        [HttpPost]
        public ActionResult DeleteAllTable_Reservation_ListBYIDs(Staff_Table_Reservation Table_Reservation_list)
        {
            Staff_Table_Reservation DL = new Staff_Table_Reservation();
            if (ModelState.IsValid)
            {
                DL.DeleteTable_Reservation_List(Table_Reservation_list);
                ModelState.Clear();
                return RedirectToAction("GetAllTable_Reservation_List", "Table_Reservation");
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