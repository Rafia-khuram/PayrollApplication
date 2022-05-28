using System;
using PayrollApplication.BOL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollApplication.BOL.ViewModels;
using System.Globalization;

namespace PayrollApplication.DAL
{
    public class SalaryDAL
    {
        private PayrollContext db = new PayrollContext();

        // Saalary CRUD
        public List<Salary> GetSalaries()
        {
            return db.Salaries.ToList();
        }

        public Salary GetSalary(int id)
        {
            return db.Salaries.Where(x => x.Id == id).FirstOrDefault();
        }
        public void AddSalary(Salary salary)
        {
            db.Salaries.Add(salary);
            db.SaveChanges();
        }
        public void DeleteSalary(int id)
        {
            db.Salaries.Remove(db.Salaries.Find(id));
            db.SaveChanges();
        }
        public void EditSalary(Salary salary)
        {
            var dbSalary = db.Salaries.Where(x => x.Id == salary.Id).FirstOrDefault();
            if (dbSalary != null)
            {
                if (!String.IsNullOrEmpty(salary.EmployeeId.ToString()))
                {
                    dbSalary.EmployeeId = salary.EmployeeId;
                }
                if (!String.IsNullOrEmpty(salary.Bonus.ToString()))
                {
                    dbSalary.Bonus = salary.Bonus;
                }
                if (!String.IsNullOrEmpty(salary.Deductions.ToString()))
                {
                    dbSalary.Deductions = salary.Deductions;
                }

                if (!String.IsNullOrEmpty(salary.Month.ToString()))
                {
                    dbSalary.Month = salary.Month;
                }
                if (!String.IsNullOrEmpty(salary.Year.ToString()))
                {
                    dbSalary.Year = salary.Year;
                }

            }
            db.SaveChanges();
        }

        public void CalculateSalary(int year,int month)
        {
            
 
             foreach(var employee in db.Users.Where(x=>x.RoleId==2)){
           
               
                    Salary salary = new Salary
                    {
                        EmployeeId = employee.Id,
                        Month = month,
                        Year = year,
                        Bonus = 0,
                        Deductions = 0
                    };
              
                        new SalaryDAL().AddSalary(salary);
                    
                   
               
            }
        }

        public int GetTotalSalary(Salary salary)
        {
            int TotalHours = 0;
            int TotalExtraHours = 0;
        //    var GivenMonthAttendance = new AttendanceDAL().GetMonthAttendance(salary.EmployeeId,salary.Month,salary.Year);
               int DaysInMonth = System.Globalization.CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(salary.Year, salary.Month); ;
            for(int i=1 ;i<=DaysInMonth ;i++)
            { 
                int CheckIn = 0;
                int CheckOut = 0;
                int BreakStart = 0;
                int BreakEnd=0;

                List<Attendance> DayAttendance = new AttendanceDAL().GetDayAttendance(salary.EmployeeId,salary.Month,salary.Year,i).ToList();
                foreach (var item in DayAttendance)
                {
                    if (item.ActivityTypeId == 1 )
                    {
                     
                        CheckIn = item.Date.Hour;
                        
                
                    }
                    if (item.ActivityTypeId == 2 )
                    {
                        CheckOut = item.Date.Hour;
                      
                    }
                    if (item.ActivityTypeId == 3 )
                    {
                        BreakStart = item.Date.Hour;
                        //if (item.Date.ToString("tt", CultureInfo.InvariantCulture).Equals("PM", StringComparison.InvariantCultureIgnoreCase)&& item.Date.Hour!=12)
                        //{
                        //      BreakStart += 12;
                        //}
                    }
                    if (item.ActivityTypeId == 4 )
                    {
                        BreakEnd = item.Date.Hour;
                     
                    }
                }

                
                int Hours = (CheckOut - CheckIn) - (BreakEnd - BreakStart);
                int Extra = 0;
                int WorkingHours = 0;
                if (Hours >= 8) {
                    Extra = Hours % 8;
                    WorkingHours = Hours - Extra;
                }
                else
                {
                    Extra = 0;
                    WorkingHours = Hours;
                }

                TotalHours += WorkingHours;
                TotalExtraHours += Extra;
            }

             List<SalarySheet> salarySheet = db.SalarySheets.Where(x => x.EmployeeId == salary.EmployeeId).ToList();
             int HoursAmount=0, BaseAmount=0, ExtraHourAmount = 0;
            foreach (var item in salarySheet)
            {
                if (item.SalaryTypeId == 1)
                {
                    BaseAmount = item.Amount;
                }
                if (item.SalaryTypeId == 2)
                {
                    HoursAmount = TotalHours * item.Amount;
                }
                if (item.SalaryTypeId == 1004)
                {
                    ExtraHourAmount = TotalExtraHours * item.Amount;
                }

               
            }
              return (BaseAmount + HoursAmount + ExtraHourAmount + salary.Bonus ) - salary.Deductions;
        }



        public List<SalaryViewModel> GetViewModelSalaries()
        {
            List<Salary> salaries = db.Salaries.ToList();
            List<SalaryViewModel> salaryView = new List<SalaryViewModel>();
            foreach (var item in salaries)
            {
                var model = new SalaryViewModel();

                model.Salary = item;
                model.TotalSalary = GetTotalSalary(item);
                salaryView.Add(model);
            }
            return salaryView;
        }

        public List<SalaryViewModel> GetViewModelSalary(int id)
        {

            return new SalaryDAL().GetViewModelSalaries().Where(x => x.Salary.EmployeeId == id).ToList();
        }
        // get number of days in current month =31
        // for loop on days
        // 1- 31
        // db .Attedance .where (x=>x.Checkin time.Month==DateTime.UtcNow.Month  && year && day)


        // CRUD SalaryType

        public List<SalaryType> GetSalaryTypes()
        {
            return db.SalaryTypes.ToList();
        }

        public SalaryType GetSalaryType(int id)
        {
            return db.SalaryTypes.Where(x => x.Id == id).FirstOrDefault();
        }

        public void AddSalaryType(SalaryType salaryType)
        {
            db.SalaryTypes.Add(salaryType);
            db.SaveChanges();
        }

        public void DeleteSalaryType(int id)
        {
            db.SalaryTypes.Remove(db.SalaryTypes.Find(id));
            db.SaveChanges();
        }

        public void EditSalaryType(SalaryType salaryType)
        {
            var dbSalaryType = db.SalaryTypes.Where(x => x.Id == salaryType.Id).FirstOrDefault();
            if (dbSalaryType != null)
            {
                if (!String.IsNullOrEmpty(salaryType.Name))
                {
                    dbSalaryType.Name = salaryType.Name; 
                }
            }
            db.SaveChanges();
        }

        //CRUD Salary Sheet

        public List<SalarySheet> GetSalarySheets()
        {
            return db.SalarySheets.ToList();
        }

        public SalarySheet GetSalarySheet(int id)
        {
            return db.SalarySheets.Where(x => x.Id == id).FirstOrDefault();
        }

        public void AddSalarySheet(SalarySheet salarySheet)
        {
            db.SalarySheets.Add(salarySheet);
            db.SaveChanges();
        }
        public void DeleteSalarySheet(int id)
        {
            db.SalarySheets.Remove(db.SalarySheets.Find(id));
            db.SaveChanges();
        }

        public void EditSalarySheet(SalarySheet salarySheet)
        {
            var dbSalarySheet = db.SalarySheets.Where(x => x.Id == salarySheet.Id).FirstOrDefault();
            if (dbSalarySheet != null)
            {
                if (!String.IsNullOrEmpty(salarySheet.EmployeeId.ToString()))
                {
                    dbSalarySheet.EmployeeId = salarySheet.EmployeeId;
                }

                if (!String.IsNullOrEmpty(salarySheet.SalaryTypeId.ToString()))
                {
                    dbSalarySheet.SalaryTypeId = salarySheet.SalaryTypeId;
                }
                if (!String.IsNullOrEmpty(salarySheet.Amount.ToString()))
                {
                    dbSalarySheet.Amount = salarySheet.Amount;
                }
                db.SaveChanges();
            }
           
        }
    }
}