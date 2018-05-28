using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _5051.Models;

namespace _5051.Backend
{
    public class contactInfoBackend
    {
        public ContactInfo Update(ContactInfo data)
        {
            data.Message = "message changed"; 
            return data; 
        }
    }
}