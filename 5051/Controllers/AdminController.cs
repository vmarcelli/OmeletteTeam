using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _5051.Models;

namespace _5051.Controllers
{
    public class AdminController : Controller
    {
       
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
            AttendanceEntryModel attendanceEntry = new AttendanceEntryModel("11:00 am", "2:00 pm");   
            return View(attendanceEntry);
        }

        // GET: Report
        public ActionResult Report()
        {
            return View();
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
    }
}