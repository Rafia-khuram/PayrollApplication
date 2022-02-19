using PayrollApplication.BAL;
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
            Response.Cookies["user-access-token"].Value = user.AccessToken;
            Response.Cookies["user-access-token"].Expires = DateTime.Now.AddDays(1);


            if (user.Role.Equals("Admin"))
            {
                return Redirect("/Admin/Index");
            }
            else
            {
                ViewBag.Error = "Email or password is incorrect or you do not have permission to access! Try again..";
                return View();
            }
        }


        public ActionResult LoginEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginEmployee(string email, string password)
        {

              var user =  new AccountBAL().GetUserInfo(email, password);
            Response.Cookies["user-access-token"].Value = user.AccessToken;
            Response.Cookies["user-access-token"].Expires = DateTime.Now.AddDays(1);


            if (user.Role.Equals("Employee"))
            {
                return Redirect("/Employee/Index");
            }
            else
            {
                ViewBag.Error = "Email or password is incorrect or you do not have permission to access! Try again..";
                return View();
            }
        }



        //[HttpPost]
        //public ActionResult Login(string email, string password)
        //{

        //    var user = new AccountBAL().GetUserInfo(email, password);
        //    Response.Cookies["user-access-token"].Value = user.AccessToken;
        //    Response.Cookies["user-access-token"].Expires = DateTime.Now.AddDays(1);
        //    if (user.Role.Equals("Admin"))
        //    {
        //        return Redirect("/Admin/Index");
        //    }

        //    else if (user.Role.Equals("Employee"))
        //    {
        //        return Redirect("/Employee/EmployeeIndex");
        //    }
        //    else
        //    {
        //        ViewBag.Error = "You do not have permission to access!";
        //        return View();
        //    }


    }
}
