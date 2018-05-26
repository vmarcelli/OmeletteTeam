using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace _5051.Models
{
    /// <summary>
    /// Avatars for the system
    /// </summary>
    public class AttendanceEntryModel
    {

        [Display(Name = "Id", Description = "AttendanceEntry Id")]
        [Required(ErrorMessage = "Id is required")]
        public string Id { get; set; }

        [Display(Name = "TimeIn", Description = "Check in Time")]
        ///[Required(ErrorMessage = "Check in time required")]
        public string TimeIn { get; set; }

        [Display(Name = "TimeOut", Description = "Check out Time")]
        public string TimeOut { get; set; }

        /// <summary>
        /// Create the default values, empty initially
        /// </summary>
        public void Initialize()
        {
            Id = Guid.NewGuid().ToString();
            TimeIn = "";
            TimeOut = "";
        }

        /// <summary>
        /// New Avatar
        /// </summary>
        public AttendanceEntryModel()
        {
            Initialize();
        }

    }
}