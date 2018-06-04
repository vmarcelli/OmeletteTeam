using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using _5051.Models;
namespace _5051.Backend
{
    public class AttendanceEntryDataSourceMock : IAttendanceEntryInterface
    {
        private static volatile AttendanceEntryDataSourceMock instance;
        private static object syncRoot = new Object();

        private AttendanceEntryDataSourceMock() { }

        public static AttendanceEntryDataSourceMock Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new AttendanceEntryDataSourceMock();
                            instance.Initialize();
                        }
                    }
                }

                return instance;
            }
        }

        private List<AttendanceEntryModel> attendanceList = new List<AttendanceEntryModel>();

        /// <summary>
        /// Makes a new Avatar
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Avatar Passed In</returns>
        public AttendanceEntryModel Create(AttendanceEntryModel data)
        {
            attendanceList.Add(data);
            return data;
        }

        /// <summary>
        /// Return the data for the id passed in
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Null or valid data</returns>
        public AttendanceEntryModel Read(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            var myReturn = attendanceList.Find(n => n.Id == id);
            return myReturn;
        }

        /// <summary>
        /// Update all attributes to be what is passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Null or updated data</returns>
        public AttendanceEntryModel Update(AttendanceEntryModel data)
        {
            if (data == null)
            {
                return null;
            }
            var myReturn = attendanceList.Find(n => n.Id == data.Id);

            myReturn.Update(data);

            return myReturn;
        }

        //update something on list
        public void Update(string id, string timeIn, string timeOut)
        {
            //find the object with that id
            foreach (var item in attendanceList)
            {
                if (item.Id == id)
                {
                    item.Update(timeIn, timeOut);
                }
            }

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

            var myData = attendanceList.Find(n => n.Id == Id);
            var myReturn = attendanceList.Remove(myData);
            return myReturn;
        }

        /// <summary>
        /// Return the full dataset
        /// </summary>
        /// <returns>List of Avatars</returns>
        public List<AttendanceEntryModel> Index()
        {
            return attendanceList;
        }

        /// <summary>
        /// Create Placeholder Initial Data
        /// </summary>
        public void Initialize()
        {
            Create(new AttendanceEntryModel("8:00 am", "11:00 am"));
            Create(new AttendanceEntryModel("8:05 am", "11:00 am"));
            Create(new AttendanceEntryModel("9:00 am", "11:00 am"));
            Create(new AttendanceEntryModel("10:00 am", "11:00 am"));
            Create(new AttendanceEntryModel("12:00 pm", "11:00 am"));
            Create(new AttendanceEntryModel("1:00 pm", "11:00 am"));
            Create(new AttendanceEntryModel("2:00 pm", "11:00 am"));
        }
    }
}