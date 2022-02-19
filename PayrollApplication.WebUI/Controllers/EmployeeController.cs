using System;
using System.Collections.Generic;
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
    }
}