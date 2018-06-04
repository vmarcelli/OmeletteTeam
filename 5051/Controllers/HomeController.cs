using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5051.Controllers
{
    /// <summary>
    /// The Home controller manages the navigation bar at the foot of the website 
    /// </summary>
    public class HomeController : Controller
    {
        // returns index view
        public ActionResult Index()
        {
            return View();
        }

        // returns home/about view
        public ActionResult About()
        {
            return View();
        }

        // returns home/contact view
        public ActionResult Contact()
        {
            return View();
        }

        // returns home/privacy view
        public ActionResult Privacy()
        {
            return View();
        }

        // returns view of the student example
        public ActionResult StudentExample()
        {
            return View();
        }

        public ActionResult HouseExample()
        {
            return View();
        }

    }
}