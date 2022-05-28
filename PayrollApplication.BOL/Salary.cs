using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollApplication.BOL
{
    public class Salary
    {
        public int Id { get; set; }
 
        public int Bonus { get; set; }
        public int Deductions { get; set; }
       

        public virtual User Employee { get; set; }
        public int EmployeeId { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }

    }

}