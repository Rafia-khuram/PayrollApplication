using PayrollApplication.BAL;
using PayrollApplication.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayrollApplication.WebUI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (new CommonController().IsAdmin(Request))
            {
                return View();
            }
            else
                return Redirect("/Home/Index");
        }
        public ActionResult AddRole()
        {
            if (new CommonController().IsAdmin(Request))
                return View();
            else
                return Redirect("/Home/Index");
        }
        [HttpPost]
        public ActionResult AddRole(Role role)
        {

            if (new CommonController().IsAdmin(Request))
            {
                new UserBAL().AddRole(role);
                return RedirectToAction("Roles");

            }
            else

                return Redirect("/Home/Index");
        }
        public ActionResult EditRole(int Id)
        {
            if (new CommonController().IsAdmin(Request))
            {
                return View(new UserBAL().GetRole(Id));
            }
            else
                return Redirect("/Home/Index");

        }
        [HttpPost]
        public ActionResult EditRole(Role role)
        {

            if (new CommonController().IsAdmin(Request))
            {
                new UserBAL().EditRole(role);
                return RedirectToAction("Roles");
            }
            else
                return Redirect("/Home/Index");

        }
        public ActionResult DeleteRole(int Id)
        {

            if (new CommonController().IsAdmin(Request))
            {
                new UserBAL().DeleteRole(Id);
                return RedirectToAction("Roles");
            }
            else
                return Redirect("/Home/AdminIndex");
        }
        public ActionResult Roles()
        {
            if (new CommonController().IsAdmin(Request))
            {
                return View(new UserBAL().GetRoles());
            }
            else
                return Redirect("/Home/Index");
        }
        public ActionResult AddUser()
        {
            if (new CommonController().IsAdmin(Request))
            {
                ViewBag.Roles = new UserBAL().GetRoles();
                return View();

            }
            else
                return Redirect("/Home/Index");
        }
        [HttpPost]
        public ActionResult Adduser(User user)
        {
            if (new CommonController().IsAdmin(Request))
            {
                new UserBAL().AddUser(user);
                return RedirectToAction("Users");

            }
            else
                return Redirect("/Home/Index");
        }
        public ActionResult EditUser(int Id)
        {
            if (new CommonController().IsAdmin(Request))
            {
                ViewBag.Roles = new UserBAL().GetRoles();
                return View(new UserBAL().GetUser(Id));

            }
            else
                return Redirect("/Home/Index");
        }
        [HttpPost]
        public ActionResult EditUser(User user)
        {
            if (new CommonController().IsAdmin(Request))
            {
                new UserBAL().EditUser(user);
                return RedirectToAction("Users");

            }
            else
                return Redirect("/Home/Index");
        }
        public ActionResult DeleteUser(int Id)
        {
            if (new CommonController().IsAdmin(Request))
            {
                new UserBAL().DeleteUser(Id);
                return RedirectToAction("Users");

            }
            else
                return Redirect("/Home/Index");
        }
        public ActionResult Users()
        {
            if (new CommonController().IsAdmin(Request))
            {

                return View(new UserBAL().GetUsers());
            }
            else
                return Redirect("/Home/Index");
        }
        public ActionResult Employees()
        {
            if (new CommonController().IsAdmin(Request))
            {

                return View(new UserBAL().GetEmployees());
            }
            else
                return Redirect("/Home/Index");
        }
    }
}