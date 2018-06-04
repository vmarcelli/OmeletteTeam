using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5051.Controllers
{
    /// <summary>
    /// Manages the student profile sign-in
    /// </summary>
    public class StudentLoginController : Controller
    {
        // returns view of the student login page
        public ActionResult Index()
        {
            return View();
        }
    }
}