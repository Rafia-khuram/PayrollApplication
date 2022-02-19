using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollApplication.BOL
{
    public class Salary
    {
        public int Id { get; set; }
        public int BaseSalary { get; set; } 
        public int Bonus { get; set; }
        public int Deductions { get; set; }
      

        public virtual User Employee { get; set; }
        public int EmployeeId { get; set; }

        public virtual Attendance Attendance { get; set; }
        public int AttendanceId { get; set; }
        public DateTime AddedOn { get; set; }

    }

}