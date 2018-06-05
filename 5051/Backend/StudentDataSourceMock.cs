using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _5051.Models;
namespace _5051.Backend
{
    public class StudentDataSourceMock : IStudentInterface
    {
        private static volatile StudentDataSourceMock instance;
        private static object syncRoot = new Object();

        private StudentDataSourceMock() { }

        public static StudentDataSourceMock Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new StudentDataSourceMock();
                            instance.Initialize();
                        }
                    }
                }

                return instance;
            }
        }

        private List<StudentModel> StudentList = new List<StudentModel>();

        /// <summary>
        /// Makes a new Student
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Student Passed In</returns>
        public StudentModel Create(StudentModel data)
        {
            StudentList.Add(data);
            return data;
        }

        /// <summary>
        /// Return the data for the id passed in
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Null or valid data</returns>
        public StudentModel Read(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var myReturn = StudentList.Find(n => n.Id == id);
            return myReturn;
        }

        /// <summary>
        /// Update all attributes to be what is passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Null or updated data</returns>
        public StudentModel Update(StudentModel data)
        {
            if (data == null)
            {
                return null;
            }
            var myReturn = StudentList.Find(n => n.Id == data.Id);

            myReturn.Update(data);

            return myReturn;
        }

        /// <summary>
        /// Remove the Data item if it is in the list
        /// </summary>
        /// <param name="data"></param>
        /// <returns>True for success, else false</returns>
        public bool Delete(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return false;
            }

            var myData = StudentList.Find(n => n.Id == Id);
            var myReturn = StudentList.Remove(myData);
            return myReturn;
        }

        /// <summary>
        /// Return the full dataset
        /// </summary>
        /// <returns>List of Students</returns>
        public List<StudentModel> Index()
        {
            return StudentList;
        }

        /// <summary>
        /// Create Placeholder Initial Data
        /// </summary>
        public void Initialize()
        {
            Create(new StudentModel("John", "student-John.jpg", "8:56 AM", "2:05 PM"));
            Create(new StudentModel("Jess", "student-Jess.jpg", "11:00 AM", "1:15 PM"));
            Create(new StudentModel("Tommy", "student-Daniel.jpg", "8:45 AM", "11:30 AM"));
            Create(new StudentModel("Jason", "student-Jason.jpg", "1:23 PM", "4:05 PM"));
            Create(new StudentModel("Dwayne", "student-Dwayne.jpg", "10:32 AM", "3:34 PM"));
            Create(new StudentModel("Reggie", "student-Reggie.jpg", "8:59 AM", "12:05 PM"));
            Create(new StudentModel("Sarah", "student-Sarah.jpg", "9:32 AM", "2:30 PM"));
            Create(new StudentModel("Taylor", "student-Taylor.jpg", "10:45 AM", "3:05 PM"));
            Create(new StudentModel("Korina", "student-Korina.jpg", "11:05 AM", "2:00 PM"));
        }
    }
}