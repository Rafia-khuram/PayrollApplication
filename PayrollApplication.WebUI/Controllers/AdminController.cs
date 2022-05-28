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

        public ActionResult FeedBacks()
        {
            if (new CommonController().IsAdmin(Request))
            {
                return View(new UserBAL().GetFeedBacks());
            }
            else
                return Redirect("/Home/Index");
        }
        public ActionResult DeleteFeedBack(int Id)
        {

            if (new CommonController().IsAdmin(Request))
            {
                new UserBAL().DeleteFeedBack(Id);
                return RedirectToAction("FeedBacks");
            }
            else
                return Redirect("/Home/Index");
        }
        //-------------------- Role Actions -------------------------------
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
                return Redirect("/Home/Index");
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
        //-------------------- Gender Actions -------------------------------
        public ActionResult AddGender()
        {
            if (new CommonController().IsAdmin(Request))
                return View();
            else
                return Redirect("/Home/Index");
        }
        [HttpPost]
        public ActionResult AddGender(Gender gender)
        {

            if (new CommonController().IsAdmin(Request))
            {
                new UserBAL().AddGender(gender);
                return RedirectToAction("Genders");

            }
            else

                return Redirect("/Home/Index");
        }
        public ActionResult EditGender(int Id)
        {
            if (new CommonController().IsAdmin(Request))
            {
                return View(new UserBAL().GetGender(Id));
            }
            else
                return Redirect("/Home/Index");

        }
        [HttpPost]
        public ActionResult EditGender(Gender gender)
        {

            if (new CommonController().IsAdmin(Request))
            {
                new UserBAL().EditGender(gender);
                return RedirectToAction("Genders");
            }
            else
                return Redirect("/Home/Index");

        }
        public ActionResult DeleteGender(int Id)
        {

            if (new CommonController().IsAdmin(Request))
            {
                new UserBAL().DeleteGender(Id);
                return RedirectToAction("Genders");
            }
            else
                return Redirect("/Home/Index");
        }
        public ActionResult Genders()
        {
            if (new CommonController().IsAdmin(Request))
            {
                return View(new UserBAL().GetGenders());
            }
            else
                return Redirect("/Home/Index");
        }

        //------------------------------------- User Actions -------------------------
        public ActionResult AddUser()
        {
            if (new CommonController().IsAdmin(Request))
            {
                ViewBag.Roles = new UserBAL().GetRoles();
                ViewBag.Genders = new UserBAL().GetGenders();
                return View();

            }
            else
                return Redirect("/Home/Index");
        }
        [HttpPost]
        public ActionResult AddUser(User user,HttpPostedFileBase image)
        {
            if (new CommonController().IsAdmin(Request))
            {

                string path = Server.MapPath("~/images");
                string fileName = Path.GetFileName(image.FileName);
                string fullPath = Path.Combine(path, fileName);
                image.SaveAs(fullPath);

                user.Image = image.FileName;
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
                ViewBag.Genders = new UserBAL().GetGenders();
                return View(new UserBAL().GetUser(Id));

            }
            else
                return Redirect("/Home/Index");
        }
        [HttpPost]
        public ActionResult EditUser(User user,HttpPostedFileBase image)
        {
            if (new CommonController().IsAdmin(Request))
            {
               string path = Server.MapPath("~/images");
                string fileName = Path.GetFileName(image.FileName);
                string fullPath = Path.Combine(path, fileName);
                image.SaveAs(fullPath);
                user.Image = image.FileName;
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

        public ActionResult DetailUser(int id)
        {
            if (new CommonController().IsAdmin(Request))
            {
                return View(new UserBAL().GetEmployee(id));
            }
            else
                return RedirectToAction("Users");
        }
        //-------------List of Employees ---------------------
        public ActionResult Employees()
        {
            if (new CommonController().IsAdmin(Request))
            {
                
                return View(new UserBAL().GetViewModelEmployees());
            }
            else
                return Redirect("/Home/Index");
        }

        public ActionResult AddAttendance(int activityTypeId, int employeeId, string employeeStatus)
        {
            if (new CommonController().IsAdmin(Request))
            {
                new AttendanceBAL().AddAttendance(activityTypeId,employeeId,employeeStatus);
                return RedirectToAction("Employees");

            }
            else
                return Redirect("/Home/Index");
        }
        //---------------------- Activity Type Actions ---------------------------------------

        public ActionResult AddActivityType()
        {
            if (new CommonController().IsAdmin(Request))
                return View();
            else
                return Redirect("/Home/Index");
        }
        [HttpPost]
        public ActionResult AddActivityType(ActivityType activityType)
        {

            if (new CommonController().IsAdmin(Request))
            {
                new AttendanceBAL().AddActivityType(activityType);
                return RedirectToAction("ActivityTypes");

            }
            else

                return Redirect("/Home/Index");
        }
        public ActionResult EditActivityType(int Id)
        {
            if (new CommonController().IsAdmin(Request))
            {
                return View(new AttendanceBAL().GetActivityType(Id));
            }
            else
                return Redirect("/Home/Index");

        }
        [HttpPost]
        public ActionResult EditActivityType(ActivityType activityType)
        {

            if (new CommonController().IsAdmin(Request))
            {
                new AttendanceBAL().EditActivityType(activityType);
                return RedirectToAction("ActivityTypes");
            }
            else
                return Redirect("/Home/Index");

        }
        public ActionResult DeleteActivityType(int Id)
        {

            if (new CommonController().IsAdmin(Request))
            {
                new AttendanceBAL().DeleteActivityType(Id);
                return RedirectToAction("ActivityTypes");
            }
            else
                return Redirect("/Home/Index");
        }
        public ActionResult ActivityTypes()
        {
            if (new CommonController().IsAdmin(Request))
            {
                return View(new AttendanceBAL().GetActivityTypes());
            }
            else
                return Redirect("/Home/Index");
        }

        //-----------------------------------------------Attendance Actions-------------------
        public ActionResult DeleteAttendance(int Id)
        {

            if (new CommonController().IsAdmin(Request))
            {
                new AttendanceBAL().DeleteAttendance(Id);
                return RedirectToAction("Attendances");
            }
            else
                return Redirect("/Home/Index");
        }
        public ActionResult Attendances()
        {
            if (new CommonController().IsAdmin(Request))
            {
                return View(new AttendanceBAL().GetAttendances());
            }
            else
                return Redirect("/Home/Index");
        }
        public ActionResult GetAttendance(int id)
        {
            if (new CommonController().IsAdmin(Request))
            {
                return View(new AttendanceBAL().GetAttendance(id));
            }
            else
                return Redirect("/Home/Index");
        }

        ///   Salary Actions
        
        public ActionResult Salaries()
        {
            if (new CommonController().IsAdmin(Request))
            {
                return View(new SalaryBAL().GetViewModelSalaries());
            }
            else
                return RedirectToAction("/Home/Index");
        }

        public ActionResult GetSalary(int id)
        {
            if (new CommonController().IsAdmin(Request))
            {
                return View(new SalaryBAL().GetViewModelSalary(id));
            }
            else
                return RedirectToAction("/Home/Index");
        }



        public ActionResult AddSalary()
        {
            if (new CommonController().IsAdmin(Request))
                return View();
            else
                return Redirect("/Home/Index");
        }
        [HttpPost]
        public ActionResult AddSalary(int year,int month)
       {

           if (new CommonController().IsAdmin(Request))
           {
               new SalaryBAL().CalculateSalary(year,month);
               return Redirect("Salaries");

           }
           else
               return Redirect("/Home/Index");
       }

        public ActionResult EditSalary(int Id)
        {
            if (new CommonController().IsAdmin(Request))
            {
                ViewBag.Users = new UserBAL().GetEmployees();
                return View(new SalaryBAL().GetSalary(Id));
            }
            else
                return Redirect("/Home/Admin");
        }
        [HttpPost]
        public ActionResult EditSalary(Salary salary)
        {
            if (new CommonController().IsAdmin(Request))
            {
                new SalaryBAL().EditSalary(salary);
                return RedirectToAction("Salaries");
            }
            else
                return Redirect("/Home/Index");
        }

        public ActionResult DeleteSalary(int id)
        {
            if (new CommonController().IsAdmin(Request))
            {
                new SalaryBAL().DeleteSalary(id);
                return RedirectToAction("Salaries");
            }
            else
                return Redirect("/Home/Index");
        }

        // ------------------------------- Salary Sheet----------------------------------------------

        public ActionResult SalarySheets()
        {
            if (new CommonController().IsAdmin(Request))
            {
                return View(new SalaryBAL().GetSalarySheets());
            }
            else
                return RedirectToAction("/Home/Index");
        }

        public ActionResult AddSalarySheet()
        {
            if (new CommonController().IsAdmin(Request))
            {
                ViewBag.Users = new UserBAL().GetEmployees();
                ViewBag.SalaryTypes = new SalaryBAL().GetSalaryTypes();
                return View();
            }
            else
                return RedirectToAction("/Home/Index");
        }
        [HttpPost]
        public ActionResult AddSalarySheet(SalarySheet salarySheet)
        {

            if (new CommonController().IsAdmin(Request))
            {
                new SalaryBAL().AddSalarySheet(salarySheet);
                return Redirect("SalarySheets");

            }
            else
                return Redirect("/Home/Index");
        }

        public ActionResult EditSalarySheet(int id)
        {
            if (new CommonController().IsAdmin(Request))
            {
                ViewBag.Users = new UserBAL().GetEmployees();
                ViewBag.SalaryTypes = new SalaryBAL().GetSalaryTypes();
                return View(new SalaryBAL().GetSalarySheet(id));
            }
            else
                return Redirect("/Home/Admin");
        }
        [HttpPost]
        public ActionResult EditSalarySheet(SalarySheet salarySheet)
        {
            if (new CommonController().IsAdmin(Request))
            {
                new SalaryBAL().EditSalarySheet(salarySheet);
                return RedirectToAction("SalarySheets");
            }
            else
                return Redirect("/Home/Index");
        }

        public ActionResult DeleteSalarySheet(int id)
        {
            if (new CommonController().IsAdmin(Request))
            {
                new SalaryBAL().DeleteSalarySheet(id);
                return RedirectToAction("SalarySheets");
            }
            else
                return Redirect("/Home/Index");
        }
        //---------------------------------------------- SalaryType --------------------------------------------------

        public ActionResult SalaryTypes()
        {
            if (new CommonController().IsAdmin(Request))
            {
                return View(new SalaryBAL().GetSalaryTypes());
            }
            else
                return RedirectToAction("/Home/Index");
        }

        public ActionResult AddSalaryType()
        {
            if (new CommonController().IsAdmin(Request))
            {
                ViewBag.SalaryTypes = new SalaryBAL().GetSalaryTypes();
                return View();
            }
            else
                return RedirectToAction("/Home/Index");
        }
        [HttpPost]
        public ActionResult AddSalaryType(SalaryType salaryType)
        {

            if (new CommonController().IsAdmin(Request))
            {
                new SalaryBAL().AddSalaryType(salaryType);
                return Redirect("SalaryTypes");

            }
            else
                return Redirect("/Home/Index");
        }

        public ActionResult EditSalaryType(int id)
        {
            if (new CommonController().IsAdmin(Request))
            {
                ViewBag.SalaryTypes = new SalaryBAL().GetSalaryTypes();
                return View(new SalaryBAL().GetSalary(id));
            }
            else
                return Redirect("/Home/Admin");
        }
        [HttpPost]
        public ActionResult EditSalaryType(SalaryType salaryType)
        {
            if (new CommonController().IsAdmin(Request))
            {
                new SalaryBAL().EditSalaryType(salaryType);
                return RedirectToAction("SalaryTypes");
            }
            else
                return Redirect("/Home/Index");
        }

        public ActionResult DeleteSalaryType(int id)
        {
            if (new CommonController().IsAdmin(Request))
            {
                new SalaryBAL().DeleteSalaryType(id);
                return RedirectToAction("SalaryTypes");
            }
            else 
                return Redirect("/Home/Index");
        }
        //  ---------------Payment Actions-----------------

        public ActionResult AddPaymentStatus()
        {
            if (new CommonController().IsAdmin(Request))
            {
             
                return View();
            }
            else
                return Redirect("/Home/Index");
        }
        [HttpPost]
        public ActionResult AddPaymentStatus(PaymentStatus paymentStatus)
        {

            if (new CommonController().IsAdmin(Request))
            {
                new PaymentBAL().AddPaymentStatus(paymentStatus);
                return RedirectToAction("PaymentStatuses");

            }
            else

                return Redirect("/Home/Index");
        }
        public ActionResult EditPaymentStatus(int Id)
        {
            if (new CommonController().IsAdmin(Request))
            {
                return View(new PaymentBAL().GetPaymentStatus(Id));
            }
            else
                return Redirect("/Home/Index");

        }
        [HttpPost]
        public ActionResult EditPaymentStatus(PaymentStatus paymentStatus)
        {

            if (new CommonController().IsAdmin(Request))
            {
                new PaymentBAL().EditPaymentStatus(paymentStatus);
                return RedirectToAction("PaymentStatuses");
            }
            else
                return Redirect("/Home/Index");

        }
        public ActionResult DeletePaymentStatus(int Id)
        {

            if (new CommonController().IsAdmin(Request))
            {
                new PaymentBAL().DeletePaymentStatus(Id);
                return RedirectToAction("PaymentStatuses");
            }
            else
                return Redirect("/Home/Index");
        }
        public ActionResult PaymentStatuses()
        {
            if (new CommonController().IsAdmin(Request))
            {
                return View(new PaymentBAL().GetPaymentStatuses());
            }
            else
                return Redirect("/Home/Index");
        }

        /////////////////////////////////
        public ActionResult AddPayment()
        {
            if (new CommonController().IsAdmin(Request))
            {
                ViewBag.Salaries = new SalaryBAL().GetSalaries();
                ViewBag.PaymentStatuses = new PaymentBAL().GetPaymentStatuses(); 
                return View();
            }
            else
                return Redirect("/Home/Index");
        }
        [HttpPost]
        public ActionResult AddPayment(Payment payment)
        {

            if (new CommonController().IsAdmin(Request))
            {
                new PaymentBAL().AddPayment(payment);
                return RedirectToAction("Payments");

            }
            else

                return Redirect("/Home/Index");
        }
        public ActionResult EditPayment(int Id)
        {
            if (new CommonController().IsAdmin(Request))
            {
                ViewBag.Salaries = new SalaryBAL().GetSalaries();
                ViewBag.PaymentStatuses = new PaymentBAL().GetPaymentStatuses();
                return View(new PaymentBAL().GetPayment(Id));
            }
            else
                return Redirect("/Home/Index");

        }
        [HttpPost]
        public ActionResult EditPayment(Payment payment)
        {

            if (new CommonController().IsAdmin(Request))
            {
               
                new PaymentBAL().EditPayment(payment);
                return RedirectToAction("Payments");
            }
            else
                return Redirect("/Home/Index");

        }
        public ActionResult DeletePayment(int Id)
        {

            if (new CommonController().IsAdmin(Request))
            {
                new PaymentBAL().DeletePayment(Id);
                return RedirectToAction("Payments");
            }
            else
                return Redirect("/Home/Index");
        }
        public ActionResult Payments()
        {
            if (new CommonController().IsAdmin(Request))
            {
                return View(new PaymentBAL().GetPayments());
            }
            else
                return Redirect("/Home/Index");
        }

        public ActionResult DetailPayment(int id)
        {
            if (new CommonController().IsAdmin(Request))
            {
                return View(new PaymentBAL().GetPayment(id));
            }
       
                return Redirect("/Home/index");
        }
    }
}