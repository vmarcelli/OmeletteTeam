﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _5051.Models;
using _5051.Backend;

namespace _5051.Controllers
{
    public class AdminController : Controller
    {
        //A ViewModel used for the Student that contains the StudentList
        private StudentViewModel StudentViewModel = new StudentViewModel();

        //The Backend Data source
        private StudentBackend StudentBackend = StudentBackend.Instance;

        private AttendanceEntryViewModel attendanceEntryViewModel = new AttendanceEntryViewModel(); 
        private AttendanceEntryDataSourceMock attendanceDataSource = AttendanceEntryDataSourceMock.Instance;
        //AttendanceEntryModel attendanceEntry = new AttendanceEntryModel("11:00 am", "2:00 pm");
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Calendar
        public ActionResult Calendar()
        {
            return View();
        }

        // GET: ExpandedStudent
        public ActionResult ExpandedStudent()
        {
            return View();
        }

        // GET: Student
        public ActionResult Student()
        {
            var myDataList = StudentBackend.Index();
            var StudentViewModel = new StudentViewModel(myDataList);
            return View(StudentViewModel);
        }

        // GET: Report
        public ActionResult Report()
        {
            var myDataList = attendanceDataSource.Index();
            var attendanceEntryViewModel = new AttendanceEntryViewModel(myDataList); 
            return View(attendanceEntryViewModel);
        }

        // GET: ReportPDF
        public ActionResult ReportPDF()
        {
            return View();
        }

        // GET: Admin
        public ActionResult Settings()
        {
            return View();
        }

        /// <summary>
        /// This will show the details of the avatar to update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Avatar/Edit/5
        public ActionResult Update(string id = null)
        {
            var myData = attendanceDataSource.Read(id);
            return View(myData);
        }

        /// <summary>
        /// This updates the avatar based on the id, timein, and timeout param.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        // POST: Admin/Update/
        [HttpPost]
        public ActionResult Update(Object sender, EventArgs e)
        {
            //variable that will hold the values posted 
            String id = "temp";
            String timeIn = "temp";
            String timeOut = "temp";
            int count = 1; 
            //a while loop that will keep on updated the data source
            //based on the values posted until there are no more values
            while (id != null)
            {
                id = Convert.ToString(Request.Form["Id" + count]);
                timeIn = Convert.ToString(Request.Form["TimeIn" + count]);
                timeOut = Convert.ToString(Request.Form["TimeOut" + count]);
                attendanceDataSource.Update(id, timeIn, timeOut);
                count++;
                id = Convert.ToString(Request.Form["Id" + count]);
            }
            return RedirectToAction("Report");
        }
    }
}