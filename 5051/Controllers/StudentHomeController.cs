using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5051.Controllers
{
    public class StudentHomeController : Controller
    {
        // returns view of the student home screen
        public ActionResult Index()
        {
            return View();
        }
    }
}