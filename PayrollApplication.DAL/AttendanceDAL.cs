using PayrollApplication.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApplication.DAL
{
    public class AttendanceDAL
    {
        PayrollContext db = new PayrollContext();
        // CRUD Activity Type
        public List<ActivityType> GetActivityTypes()
        {
            return db.ActivityTypes.ToList();
        }

        public ActivityType GetActivityType(int id)
        {
            return db.ActivityTypes.Where(x => x.Id == id).FirstOrDefault();
        }

        public void AddActivityType(ActivityType activityType)
        {
            db.ActivityTypes.Add(activityType);
            db.SaveChanges();
        }

        public void DeleteActivityType(int id)
        {
            db.ActivityTypes.Remove(db.ActivityTypes.Find(id));
            db.SaveChanges();
        }

        public void EditActivityType(ActivityType activityType)
        {
            var dbActivityType = db.ActivityTypes.Where(x => x.Id == activityType.Id).FirstOrDefault();
            if (dbActivityType != null)
            {
                if (!String.IsNullOrEmpty(activityType.Name))
                {
                    dbActivityType.Name = activityType.Name;
                }
            }
            db.SaveChanges();
        }
        // CRUD Attendance

        public List<Attendance> GetAttendances()
        {
            return db.Attendances.ToList();
        }

        public List<Attendance> GetAttendance(int id)
        {
            return db.Attendances.Where(x => x.EmployeeId == id).ToList();
        }

        //public List<Attendance> GetMonthAttendance(int id ,string month)
        //{
        //    return db.Attendances.Where(x => x.EmployeeId == id && x.Date.ToString("MMMM").Equals(month, StringComparison.InvariantCultureIgnoreCase)).ToList();
        //}

        public List<Attendance> GetDayAttendance(int employeeId, int month ,int year, int day)
        {
            return db.Attendances.Where(x => x.EmployeeId == employeeId && x.Date.Day == day && x.Date.Month == month && x.Date.Year==year).ToList();
        }
        public void DeleteAttendance(int id)
        {
            db.Attendances.Remove(db.Attendances.Find(id));
            db.SaveChanges();
        }
        public void AddAttendance(Attendance attendance)
        {
            db.Attendances.Add(attendance);
            db.SaveChanges();
        }

    }
}
