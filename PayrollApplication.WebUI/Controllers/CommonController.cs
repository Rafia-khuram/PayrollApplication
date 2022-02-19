using PayrollApplication.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayrollApplication.WebUI.Controllers
{
    public class CommonController : Controller
    {

        public bool IsEmployee(HttpRequestBase requestbase)
        {
            if (requestbase.Cookies["user-access-token"] != null)
            {
                var RoleId = new AccountBAL().GetUserRole((requestbase.Cookies["user-access-token"].Value));
                if (RoleId == 2)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsAdmin(HttpRequestBase requestbase)
        {
            if (requestbase.Cookies["user-access-token"] != null)
            {
                var RoleId = new AccountBAL().GetUserRole(requestbase.Cookies["user-access-token"].Value);
                if (RoleId == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}