using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollApplication.BOL
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime AttendanceDate { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public DateTime BreakStart { get; set; }
        public DateTime BreakEnd { get; set; }

        public virtual User Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}