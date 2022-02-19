using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollApplication.BOL
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime IssuedDate { get; set; }

        public virtual Salary Salary { get; set; }
        public int SalaryId { get; set; }

        public virtual PaymentStatus PaymentStatus { get; set; }
        public int PaymentStatusId { get; set; }
    }
}