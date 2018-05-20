using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5051.Controllers
{
    /*
     * Admin Student tab Controller lists out the 
     * students in the class with a small amount of 
     * information
     */
    public class AdminStudentController : Controller
    {
        // GET: AdminStudent
        public ActionResult Index()
        {
            return View();
        }
    }
}