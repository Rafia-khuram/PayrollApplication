using PayrollApplication.BAL;
using PayrollApplication.BOL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayrollApplication.WebUI.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            if (new CommonController().IsEmployee(Request))

                return View();
            else
                return Redirect("/Home/Index");
        }

       public ActionResult Detail()
       {
           User employee = new CommonController().GetEmployee(Request);
           return View(employee);
       }

        public ActionResult EditProfile(int Id)
        {
            if (new CommonController().IsEmployee(Request))
            {
                ViewBag.Roles = new UserBAL().GetRoles();
                ViewBag.Genders = new UserBAL().GetGenders();
                return View(new UserBAL().GetUser(Id));

            }
            else
                return Redirect("/Home/Index");
        }
        [HttpPost]
        public ActionResult EditProfile(User user, HttpPostedFileBase image)
        {
            if (new CommonController().IsEmployee(Request))
            {
                string path = Server.MapPath("~/images");
                string fileName = Path.GetFileName(image.FileName);
                string fullPath = Path.Combine(path, fileName);
                image.SaveAs(fullPath);
                user.Image = image.FileName;
                new UserBAL().EditUser(user);
                return RedirectToAction("Detail");

            }
            else
                return Redirect("/Home/Index");
        }


        public ActionResult Attendance()
        {
            User employee = new CommonController().GetEmployee(Request);
            return View(new AttendanceBAL().GetAttendance(employee.Id));
        }

        public ActionResult Salary()
        {
            User employee = new CommonController().GetEmployee(Request);
            return View(new SalaryBAL().GetViewModelSalary(employee.Id));
        }

        public ActionResult Payment()
        {
            User employee = new CommonController().GetEmployee(Request);
            return View(new PaymentBAL().GetPayment(employee.Id));
        }
        public ActionResult AddFeedBack()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFeedback(FeedBack feedBack)
        {

            new UserBAL().AddFeedBack(feedBack);
            return RedirectToAction("Index");

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
