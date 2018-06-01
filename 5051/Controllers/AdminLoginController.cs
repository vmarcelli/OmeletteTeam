using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5051.Controllers
{
    /// <summary>
    /// The AdminLoginController manages the Administrator login page 
    /// </summary>
    public class AdminLoginController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}