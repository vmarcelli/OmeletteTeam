using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5051.Controllers
{   
    /*
     * Expanded Student tab from Admin Student tab, allows for
     * a larger information view of a student
     */
    public class AdminExpandedStudentController : Controller
    {
        // GET: AdminExpandedStudent
        public ActionResult Index()
        {
            return View();
        }
    }
}