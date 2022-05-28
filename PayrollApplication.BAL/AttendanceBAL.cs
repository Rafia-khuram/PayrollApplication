using PayrollApplication.BOL;
using PayrollApplication.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApplication.BAL
{
    public class AttendanceBAL
    {
        public void AddActivityType(ActivityType activityType)
        {
            new AttendanceDAL().AddActivityType(activityType);
        }
        public ActivityType GetActivityType(int Id)
        {
            return new AttendanceDAL().GetActivityType(Id);
        }
        public void EditActivityType(ActivityType activityType)
        {
            new AttendanceDAL().EditActivityType(activityType);
        }
        public void DeleteActivityType(int Id)
        {
            new AttendanceDAL().DeleteActivityType(Id);
        }
        public List<ActivityType> GetActivityTypes()
        {
            return new AttendanceDAL().GetActivityTypes();
        }

        //-----------------------------------------------------//

        // CRUD Attendance

        public List<Attendance> GetAttendances()
        {
            return new AttendanceDAL().GetAttendances();
        }

        public List<Attendance> GetAttendance(int id)
        {
            return new AttendanceDAL().GetAttendance(id);
        }

        public void DeleteAttendance(int id)
        {
            new AttendanceDAL().DeleteAttendance(id);
        }

        public void AddAttendance(int activityTypeId,int employeeId ,string employeeStatus)
        {
           
            {
                var attendance = new Attendance
                {
                    Date = DateTime.UtcNow.AddHours(5),
                    EmployeeId = employeeId,
                    ActivityTypeId = activityTypeId
                };

                new AttendanceDAL().AddAttendance(attendance);
            }
            
        }
    }
}
