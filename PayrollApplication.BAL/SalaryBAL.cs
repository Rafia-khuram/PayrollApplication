using PayrollApplication.BOL;
using PayrollApplication.BOL.ViewModels;
using PayrollApplication.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApplication.BAL
{
     public class SalaryBAL
    {
        // Saalary CRUD
        public List<Salary> GetSalaries()
        {
            return new SalaryDAL().GetSalaries();
        }
        public List<SalaryViewModel> GetViewModelSalaries()
        {
            return new SalaryDAL().GetViewModelSalaries();
        }
        public List<SalaryViewModel> GetViewModelSalary(int id)
        {
            return new SalaryDAL().GetViewModelSalary(id);

        }

        public Salary GetSalary(int id)
        {
            return new SalaryDAL().GetSalary(id);
        }
        public void AddSalary(Salary salary)
        {
         new SalaryDAL().AddSalary(salary);
        }
        public void DeleteSalary(int id)
        {
            new SalaryDAL().DeleteSalary(id);
        }
        public void EditSalary(Salary salary)
        {
            new SalaryDAL().EditSalary(salary);
        }

        // CRUD SalaryType

        public List<SalaryType> GetSalaryTypes()
        {
            return new SalaryDAL().GetSalaryTypes();
        }

        public SalaryType GetSalaryType(int id)
        {
            return new SalaryDAL().GetSalaryType(id);
        }

        public void AddSalaryType(SalaryType salaryType)
        {
            new SalaryDAL().AddSalaryType(salaryType);
        }

        public void DeleteSalaryType(int id)
        {
            new SalaryDAL().DeleteSalaryType(id);
        }

        public void EditSalaryType(SalaryType salaryType)
        {
            new SalaryDAL().EditSalaryType(salaryType);
        }

        //CRUD Salary Sheet

        public List<SalarySheet> GetSalarySheets()
        {
            return new SalaryDAL().GetSalarySheets();
        }

        public SalarySheet GetSalarySheet(int id)
        {
            return new SalaryDAL().GetSalarySheet(id);
        }

        public void AddSalarySheet(SalarySheet salarySheet)
        {
            new SalaryDAL().AddSalarySheet(salarySheet);
        }
        public void DeleteSalarySheet(int id)
        {
            new SalaryDAL().DeleteSalarySheet(id);
        }

        public void EditSalarySheet(SalarySheet salarySheet)
        {
            new SalaryDAL().EditSalarySheet(salarySheet);
        }

        public void CalculateSalary(int year,int month)
        {
            new SalaryDAL().CalculateSalary(year,month);
        }
    }
}

