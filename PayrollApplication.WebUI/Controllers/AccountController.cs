using PayrollApplication.BAL;
using PayrollApplication.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayrollApplication.WebUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {

            var user = new AccountBAL().GetUserInfo(email, password);
            if (user != null)
            {
                Response.Cookies["user-access-token"].Value = user.AccessToken;
                Response.Cookies["user-access-token"].Expires = DateTime.Now.AddDays(1);
                if (user.Role.Equals("Admin"))
                {
                    return Redirect("/Admin/Index");
                }

                if (user.Role.Equals("Employee"))
                {
                    return Redirect("/Employee/Index");
                }
            }
           
            else
            {
                ViewBag.Error = "Login Failed! Email or password is incorrect";
                return View();
            }

            return View();
        }

           public ActionResult LogOut()
        {
            if (Request.Cookies["user-access-token"] != null)
            {
                Response.Cookies["user-access-token"].Expires = DateTime.UtcNow.AddHours(5);
            }
            return Redirect("/Home/Index");
        }
     
    }
}
