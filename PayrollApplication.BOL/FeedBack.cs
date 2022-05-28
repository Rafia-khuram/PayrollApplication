using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollApplication.BOL
{
    public class FeedBack
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Message{ get; set; }
        public string Email { get; set; }
        public DateTime FeedbackTime { get; set; }
    }
}