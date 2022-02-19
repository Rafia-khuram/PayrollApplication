using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollApplication.BOL
{
    public class SalarySheet
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public virtual User Employee { get; set; }
        public int EmployeeId { get; set; }

        public virtual SalaryType SalaryType { get; set; }
        public int SalaryTypeId { get; set; }
    }
}