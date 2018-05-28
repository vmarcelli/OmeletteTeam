using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _5051.Models;
using _5051.Backend;

namespace _5051.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var contact = new ContactInfo() { Id=1, Name = "Peter Pan", Message="This is a message" }; 
            return View(contact);
        }

        public ActionResult Update([Bind(Include =
                                        "Id,"+
                                        "Name,"+
                                        "Message,"+
                                        "")] ContactInfo data)
        {
           
            return RedirectToAction("Index"); 
        }
    }
}