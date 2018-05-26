using _5051.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _5051.Backend
{
    /// <summary>
    /// Avatar Backend handles the business logic and data for Avatars
    /// </summary>
    public class AttendanceEntryBackend
    {
        private static volatile AttendanceEntryBackend instance;
        private static object syncRoot = new Object();

        private AttendanceEntryBackend() { }

        public static AttendanceEntryBackend Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new AttendanceEntryBackend();
                            SetDataSource(SystemGlobals.Instance.DataSourceValue);
                        }
                    }
                }

                return instance;
            }
        }

        // Get the Datasource to use
        private static IAttendanceEntryInterface DataSource;

        public static void SetDataSource(DataSourceEnum dataSourceEnum)
        {
            if (dataSourceEnum == DataSourceEnum.SQL)
            {
                // SQL not hooked up yet...
                throw new NotImplementedException();
            }

            // Default is to use the Mock
            DataSource = AttendanceEntryDataSourceMock.Instance;
        }


        /// <summary>
        /// Makes a new Avatar
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Avatar Passed In</returns>
        public AttendanceEntryModel Create(AttendanceEntryModel data)
        {
            DataSource.Create(data);
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

            var myReturn = DataSource.Read(id);
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

            var myReturn = DataSource.Update(data);

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

            var myReturn = DataSource.Delete(Id);
            return myReturn;
        }

        /// <summary>
        /// Return the full dataset
        /// </summary>
        /// <returns>List of Avatars</returns>
        public List<AttendanceEntryModel> Index()
        {
            var myData = DataSource.Index();
            return myData;
        }

        /// <summary>
        /// Helper that returns the First Avatar ID in the list, this will be used for creating new avatars if no avatarID is specified
        /// </summary>
        /// <returns>Null, or Avatar ID of the first avatar in the list.</returns>
        public string GetFirstAttendanceEntryId()
        {
            string myReturn = null;

            var myData = DataSource.Index().ToList().FirstOrDefault();
            if (myData != null)
            {
                myReturn = myData.Id;
            }

            return myReturn;
        }

        /// <summary>
        /// Helper function that returns the Avatar Image URI
        /// </summary>
        /// <param name="data">The avatarId to look up</param>
        /// <returns>null, or the avatar image URI</returns>
        public string GetAttendanceTimeIn(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }

            string myReturn = null;

            var myData = DataSource.Read(data);
            if (myData != null)
            {
                myReturn = myData.TimeIn;
            }

            return myReturn;
        }

        /// <summary>
        /// Helper function that returns the Avatar Image URI
        /// </summary>
        /// <param name="data">The avatarId to look up</param>
        /// <returns>null, or the avatar image URI</returns>
        public string GetAttendanceTimeOut(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }

            string myReturn = null;

            var myData = DataSource.Read(data);
            if (myData != null)
            {
                myReturn = myData.TimeOut;
            }

            return myReturn;
        }

        /// <summary>
        /// Helper that gets the list of Items, and converst them to a SelectList, so they can show in a Drop Down List box
        /// </summary>
        /// <param name="id">optional paramater, of the Item that is currently selected</param>
        /// <returns>List of SelectListItems as a SelectList</returns>
        //public List<SelectListItem> GetAvatarListItem(string id = null)
        //{
        //    var myDataList = DataSource.Index();

        //    //var myReturn = new SelectList(myDataList);

        //    var myReturn = myDataList.Select(a => new SelectListItem
        //    {
        //        Text = a.Name,
        //        Value = a.Id,
        //        Selected = (a.Id == id),
        //    }).ToList();

        //    return myReturn;
        //}
    }
}