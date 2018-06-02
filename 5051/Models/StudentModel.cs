using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using _5051.Backend;

namespace _5051.Models
{
    /// <summary>
    /// The Student, this holds the student id, name, tokens.  Other things about the student such as their attendance is pulled from the attendance data, or the owned items, from the inventory data
    /// </summary>
    public class StudentModel
    {
        [Key]
        [Display(Name = "Id", Description = "Student Id")]
        [Required(ErrorMessage = "Id is required")]
        public string Id { get; set; }


        [Display(Name = "Name", Description = "Student Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        // photo of student 
        [Display(Name = "AvatarId", Description = "Avatar")]
        [Required(ErrorMessage = "Avatar is required")]
        public string AvatarId { get; set; }

        [Display(Name = "Current Status", Description = "Status of the Student")]
        [Required(ErrorMessage = "Status is required")]
        public StudentStatusEnum Status { get; set; }

        // student time in 
        [Display(Name = "TimeIn", Description = "Check in time")]
        [Required(ErrorMessage = "time in is required")]
        public string TimeIn { get; set; }

        // student time out
        [Display(Name = "TimeOut", Description = "Check out time")]
        [Required(ErrorMessage = "time out is required")]
        public string TimeOut { get; set; }

        /// <summary>
        /// The defaults for a new student
        /// </summary>
        public void Initialize()
        {
            Id = Guid.NewGuid().ToString();
            Status = StudentStatusEnum.Out;
        }

        /// <summary>
        /// Constructor for a student
        /// </summary>
        public StudentModel()
        {
            Initialize();
        }

        /// <summary>
        /// Constructor for Student.  Call this when making a new student
        /// </summary>
        /// <param name="name">The Name to call the student</param>
        /// <param name="avatarId">The avatar to use, if not specified, will call the backend to get an ID</param>
        public StudentModel(string name, string avatarId, string timeIn, string timeOut)
        {
            Initialize();

            Name = name;

            // If no avatar ID is sent in, then go and get the first avatar ID from the backend data as the default to use.
            if (string.IsNullOrEmpty(avatarId))
            {
                avatarId = AvatarBackend.Instance.GetFirstAvatarId();
            }
            AvatarId = avatarId;

            TimeIn = timeIn;
            TimeOut = timeOut; 
        }

        /// <summary>
        /// Convert a Student Display View Model, to a Student Model, used for when passed data from Views that use the full Student Display View Model.
        /// </summary>
        /// <param name="data">The student data to pull</param>
        public StudentModel(StudentDisplayViewModel data)
        {
            Id = data.Id;
            Name = data.Name;
            AvatarId = data.AvatarId;
            Status = data.Status;

            TimeIn = data.TimeIn;       // set time in 
            TimeOut = data.TimeOut;     // set time out 
        }

        /// <summary>
        /// Update the Data Fields with the values passed in, do not update the ID.
        /// </summary>
        /// <param name="data">The values to update</param>
        /// <returns>False if null, else true</returns>
        public bool Update(StudentModel data)
        {
            if (data == null)
            {
                return false;
            }

            Name = data.Name;
            AvatarId = data.AvatarId;
            Status = data.Status;
            TimeIn = data.TimeIn;       // set time in 
            TimeOut = data.TimeOut;     // set time out 

            return true;
        }
    }

    /// <summary>
    /// For the Index View, add the Avatar URI to the Student, so it shows the student with the picture
    /// </summary>
    public class StudentDisplayViewModel : StudentModel
    {
        [Display(Name = "Student Picture", Description = "Student Picture to Show")]
        public string PhotoId { get; set; }

        [Display(Name = "Student Name", Description = "Student Name")]
        public string StudentName { get; set; }

        [Display(Name = "Student Id", Description = "Student Id")]
        public string StudentId { get; set; }

        public StudentDisplayViewModel() { }

        /// <summary>
        /// Creates a Student Display View Model from a Student Model
        /// </summary>
        /// <param name="data">The Student Model to create</param>
        public StudentDisplayViewModel(StudentModel data)
        {
            Id = data.Id;
            Name = data.Name;
            AvatarId = data.AvatarId;
            Status = data.Status;
            TimeIn = data.TimeIn;       // set time in 
            TimeOut = data.TimeOut;     // set time out 

            //Use this template for including other objects in View Model

            //var myDataAvatar = StudentBackend.Instance.Read(StudentId);
            //if (myDataAvatar == null)
            //{
                // Nothing to convert
            //    return;
            //}

            //StudentName = myDataAvatar.Name;
            //PhotoId = myDataAvatar.AvatarId;
        }
    }

    /// <summary>
    /// Student Status Options
    /// </summary>
    public enum StudentStatusEnum
    {
        // Logged Out
        Out = 1,
        
        // Logged In
        In = 2,

        // Student on hold
        Hold = 3
    }
}