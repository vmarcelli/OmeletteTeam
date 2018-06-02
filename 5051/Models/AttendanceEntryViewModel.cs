using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5051.Models
{
    /// <summary>
    /// View Model for the Student Index, this will have the list of the students in it convered to a StudentDisplayViewModel
    /// </summary>
    public class AttendanceEntryViewModel
    {
        public List<AttendanceEntryModel> AttendanceList = new List<AttendanceEntryModel>();

        public AttendanceEntryViewModel() { }

        /// <summary>
        /// Take the data list passed in, and convert each to a new StudentDisplayViewModel item and add that to the StudentList
        /// </summary>
        /// <param name="dataList"></param>
        public AttendanceEntryViewModel(List<AttendanceEntryModel> dataList)
        {
            foreach (var item in dataList)
            {
                AttendanceList.Add(item);
            }
        }
    }
}