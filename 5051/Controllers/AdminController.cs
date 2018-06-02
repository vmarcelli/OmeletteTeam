using System;
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
        /// This updates the avatar based on the information posted from the udpate page
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        // POST: Avatar/Update/5
        [HttpPost]
        public ActionResult Update([Bind(Include=
                                        "Id,"+
                                        "TimeIn,"+
                                        "TimeOut,"+
                                        "")] AttendanceEntryModel data)
        {

            if (data == null)
            {
                // Send to error page
                return RedirectToAction("Error", new { route = "Home", action = "Error" });
            }

            if (string.IsNullOrEmpty(data.Id))
            {
                // Send back for Edit
                return View(data);
            }

            //Update
            attendanceDataSource.Update(data);
            return RedirectToAction("Student");
        }
    }
}