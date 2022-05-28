using PayrollApplication.BOL;
using PayrollApplication.BOL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PayrollApplication.DAL
{
    public class UserDAL
    {
        private readonly PayrollContext db = new PayrollContext();

        public List<User> GetUsers(){
            return db.Users.ToList();
        }
        public List<User> GetEmployees()
        {
            return db.Users.Where(x => x.RoleId != 1).ToList();
        }

        public List<EmployeeViewModel> GetViewModelEmployees()
        {
            List<User> employees = db.Users.Where(x => x.RoleId == 2).ToList();
            List<EmployeeViewModel> employeeView = new List<EmployeeViewModel>();
            foreach (var item in employees)
            {
                var Attendance = db.Attendances.Where(x => x.EmployeeId == item.Id).OrderByDescending(x => x.Id).FirstOrDefault();
                var model = new EmployeeViewModel();
                {
                    model.Employee = item;
                    if (Attendance != null)
                    {
                        model.EmployeeStatus = Attendance.ActivityType.Name;
                    }
                    else
                    {
                        model.EmployeeStatus = "Absent";
                    }
                }
                employeeView.Add(model);
            }
            return employeeView;
        }
        public User GetUser(int id)
        {
            return db.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void AddFeedBack(FeedBack feedBack )
        {
            db.FeedBacks.Add(feedBack);
            db.SaveChanges();
        }


        public void DeleteUser(int id)
        {
            db.Users.Remove(db.Users.Find(id));
            db.SaveChanges();
        }
        public void EditUser(User user)
        {
            
            var dbUser = db.Users.Where(x => x.Id == user.Id).FirstOrDefault();
            if (dbUser != null)
            {
                if (!String.IsNullOrEmpty(user.Name))
                {
                    dbUser.Name = user.Name;

                }
                if (!String.IsNullOrEmpty(user.Email))
                {
                    dbUser.Email = user.Email;

                }
                if (!String.IsNullOrEmpty(user.Password))
                {
                    dbUser.Password = user.Password;

                }
                if (!String.IsNullOrEmpty(user.PhoneNumber))
                {
                    dbUser.PhoneNumber = user.PhoneNumber;

                }

                if (!String.IsNullOrEmpty(user.RoleId.ToString()))
                {
                    dbUser.RoleId = user.RoleId;

                }
                if (!String.IsNullOrEmpty(user.Image))
                {
                    dbUser.Image = user.Image;
                }

                if (!String.IsNullOrEmpty(user.Address))
                {
                    dbUser.Address = user.Address;
                }

            }
            db.SaveChanges();
        }

        public User GetEmployee(int id)
        {
            return db.Users.Where(x => x.Id == id).FirstOrDefault();
        }


        //       CRUD Role
        public List<Role> GetRoles()
        {
            return db.Roles.ToList();
        }

        public Role GetRole(int id)
        {
            return db.Roles.Where(x => x.Id == id).FirstOrDefault();
        }

        public void AddRole(Role role)
        {
            db.Roles.Add(role);
            db.SaveChanges();
        }

        public void DeleteRole(int id)
        {
            db.Roles.Remove(db.Roles.Find(id));
            db.SaveChanges();
        }

        public void EditRole(Role role)
        {
            var dbRole = db.Roles.Where(x => x.Id == role.Id).FirstOrDefault();
            if(dbRole != null)
            {
                if (!String.IsNullOrEmpty(role.Name))
                {
                    dbRole.Name = role.Name;
                }
            }
            db.SaveChanges();
        }

        // Gender CRUD
        public List<Gender> GetGenders()
        {
            return db.Genders.ToList();
        }

        public Gender GetGender(int id)
        {
            return db.Genders.Where(x => x.Id == id).FirstOrDefault();
        }

        public void AddGender(Gender gender)
        {
            db.Genders.Add(gender);
            db.SaveChanges();
        }

        public void DeleteGender(int id)
        {
            db.Genders.Remove(db.Genders.Find(id));
            db.SaveChanges();
        }

        public void EditGender(Gender gender)
        {
            var dbGender = db.Genders.Where(x => x.Id == gender.Id).FirstOrDefault();
            if (dbGender != null)
            {
                if (!String.IsNullOrEmpty(gender.Name))
                {
                    dbGender.Name = gender.Name;
                }
            }
            db.SaveChanges();
        }

        // CRUD Feedback

        public List<FeedBack> GetFeedBacks()
        {
            return db.FeedBacks.ToList();
        }

        public FeedBack GetFeedback(int id)
        {
            return db.FeedBacks.Where(x => x.Id == id).FirstOrDefault();
        }

        public void DeleteFeedBack(int id)
        {
            db.FeedBacks.Remove(db.FeedBacks.Find(id));
            db.SaveChanges();
        }

        //public void EditFeedBack(FeedBack feedBack)
        //{
        //    var dbFeedBack = db.FeedBacks.Where(x => x.Id == feedBack.Id).FirstOrDefault();
        //    if (dbFeedBack != null)
        //    {
        //        if (!String.IsNullOrEmpty(feedBack.EmployeeId.ToString()))
        //        {
        //            dbFeedBack.EmployeeId = feedBack.EmployeeId;
        //        }
        //        if (!String.IsNullOrEmpty(feedBack.Title))
        //        {
        //            dbFeedBack.Title = feedBack.Title;
        //        }
        //        if (!String.IsNullOrEmpty(feedBack.EmployeeId.ToString()))
        //        {
        //            dbFeedBack.Description = feedBack.Description;
        //        }

        //    }
        //    db.SaveChanges();
        //}
    }
}
