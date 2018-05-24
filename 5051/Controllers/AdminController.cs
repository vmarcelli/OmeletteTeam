using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View("Calendar");
        }

        // GET: ExpandedStudent
        public ActionResult ExpandedStudent()
        {
            return View("ExpandedStudent");
        }

        // GET: Student
        public ActionResult Student()
        {
            return View("Student");
        }

        // GET: Report
        public ActionResult Report()
        {
            return View("Report");
        }

        // GET: ReportPDF
        public ActionResult ReportPDF()
        {
            return View("ReportPDF");
        }
    }
}