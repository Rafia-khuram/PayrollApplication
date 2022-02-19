using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollApplication.BOL
{
    public class FeedBack
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual User Employee { get; set; }
        public int EmployeeId { get; set; }
        public DateTime FeedbackTime { get; set; }
    }
}