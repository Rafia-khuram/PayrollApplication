using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollApplication.BOL
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public virtual ActivityType ActivityType { get; set; }
        public int ActivityTypeId { get; set; }

        public virtual User Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}
