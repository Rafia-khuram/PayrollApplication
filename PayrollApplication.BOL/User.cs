using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayrollApplication.BOL
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email{ get; set; }
        public string Password { get; set; }
        public string Image{ get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public virtual Gender Gender { get; set; }
        public int GenderId { get; set; }
        public virtual Role Role { get; set; }
        public int RoleId { get; set; }
        public string AccessToken { get; set; }
    }
}