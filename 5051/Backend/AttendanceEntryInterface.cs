using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _5051.Models;

namespace _5051.Backend
{
    public interface IAttendanceEntryInterface
    {
        AttendanceEntryModel Create(AttendanceEntryModel data);
        AttendanceEntryModel Read(string id);
        AttendanceEntryModel Update(AttendanceEntryModel data);
        bool Delete(string id);
        List<AttendanceEntryModel> Index();
    }
}