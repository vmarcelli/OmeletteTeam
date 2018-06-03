using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _5051.Models;
using _5051.Backend;

namespace _5051.Controllers
{
    /// <summary>
    /// The Kiosk that will run in the classroom
    /// </summary>
    public class KioskController : Controller
    {
        // A ViewModel used for the Student that contains the StudentList
        private StudentViewModel StudentViewModel = new StudentViewModel();

        // The Backend Data source
        private StudentBackend StudentBackend = StudentBackend.Instance;

        /// <summary>
        /// Return the list of students with the status of logged in or out
        /// </summary>
        /// <returns></returns>
        // GET: Kiosk
        public ActionResult Index()
        {
            var myDataList = StudentBackend.Index();
            var StudentViewModel = new StudentViewModel(myDataList);
            return View(StudentViewModel);
        }

        public ActionResult Update(string id=null)
        {
            var myData = StudentBackend.Read(id);
            return View(myData);
        }

        [HttpPost]
        public ActionResult Index([Bind(Include =
                                        "Id," +
                                        "Name," +
                                        "AvatarId," +
                                        "Status," +
                                        "TimeIn," +
                                        "TimeOut," +
                                        "")] StudentModel data)
        {
            if (data == null)
            {
                return RedirectToAction("Error", new { route = "Home", action = "Error" });
            }

            if (string.IsNullOrEmpty(data.Id))
            {
                return View(data);
            }
            if (data.Status == StudentStatusEnum.In)
            {
                data.Status = StudentStatusEnum.Out;
            } else
            {
                data.Status = StudentStatusEnum.In;
            }
            StudentBackend.Update(data);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update([Bind(Include = 
                                        "Id," +
                                        "Name," +
                                        "AvatarId," +
                                        "Status," +
                                        "TimeIn," +
                                        "TimeOut," +
                                        "")] StudentModel data) 
        {
            if (data == null)
            {
                return RedirectToAction("Error", new { route = "Home", action = "Error" });
            }

            if (string.IsNullOrEmpty(data.Id))
            {
                return View(data);
            }
            StudentBackend.Update(data);
            return RedirectToAction("Index");
        }

        // GET: Kiosk/SetLogout/5
        public ActionResult SetLogin(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Error","Home","Invalid Data");
            }

            StudentBackend.ToggleStatusById(id);
            return RedirectToAction("Index");
        }

        // GET: Kiosk/SetLogout/5
        public ActionResult SetLogout(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Error", "Home", "Invalid Data");
            }

            StudentBackend.ToggleStatusById(id);
            return RedirectToAction("Index");
        }
    }
}
