using System;
using PayrollApplication.BOL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if(dbSalary != null)
            {
                if (String.IsNullOrEmpty(salary.EmployeeId.ToString())){
                    dbSalary.EmployeeId = salary.EmployeeId;
                }
                if (String.IsNullOrEmpty(salary.BaseSalary.ToString()))
                {
                    dbSalary.BaseSalary = salary.BaseSalary;
                }
                if (String.IsNullOrEmpty(salary.Bonus.ToString()))
                {
                    dbSalary.Bonus = salary.Bonus;
                }
                if (String.IsNullOrEmpty(salary.Deductions.ToString()))
                {
                    dbSalary.Deductions = salary.Deductions;
                }
                if (String.IsNullOrEmpty(salary.AttendanceId.ToString()))
                {
                    dbSalary.AttendanceId = salary.AttendanceId;
                }
              
            }

            db.SaveChanges();
        }

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
            if (dbSalaryType!= null)
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
            }
            db.SaveChanges();
        }
    }
}
