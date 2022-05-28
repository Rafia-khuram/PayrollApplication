
using PayrollApplication.BOL;
using PayrollApplication.BOL.ViewModels;
using PayrollApplication.DAL;
using PayrollApplication.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
namespace PayrollApplication.BAL
{
    public class UserBAL
    {

        public void AddFeedBack(FeedBack feedBack)
        {
            feedBack.FeedbackTime = DateTime.UtcNow.AddHours(5);
            new UserDAL().AddFeedBack(feedBack);
        }
        public List<FeedBack> GetFeedBacks()
        {
            return new UserDAL().GetFeedBacks();
        }
        public void DeleteFeedBack(int Id)
        {
            new UserDAL().DeleteFeedBack(Id);
        }
        public void AddRole(Role role)
        {
            new UserDAL().AddRole(role);
        }
        public Role GetRole(int Id)
        {
            return new UserDAL().GetRole(Id);
        }
        public void EditRole(Role role)
        {
            new UserDAL().EditRole(role);
        }
        public void DeleteRole(int Id)
        {
            new UserDAL().DeleteRole(Id);
        }
        public List<Role> GetRoles()
        {
            return new UserDAL().GetRoles();
        }

        // 
        public void AddGender(Gender gender)
        {
            new UserDAL().AddGender(gender);
        }
        public Role GetGender(int Id)
        {
            return new UserDAL().GetRole(Id);
        }
        public void EditGender(Gender gender)
        {
            new UserDAL().EditGender(gender);
        }
        public void DeleteGender(int Id)
        {
            new UserDAL().DeleteGender(Id);
        }
        public List<Gender> GetGenders()
        {
            return new UserDAL().GetGenders();
        }

          public void AddUser(User user)
        {
           user.AccessToken = RandomHandler.GenerateAccessToken();
            new UserDAL().AddUser(user);
        }

        public User GetUser(int Id)
        {
            return new UserDAL().GetUser(Id);
        }
        public void EditUser(User user)
        {
            new UserDAL().EditUser(user);
        }
        public void DeleteUser(int Id)
        {
            new UserDAL().DeleteUser(Id);
        }
        public List<User> GetUsers()
        {
            return new UserDAL().GetUsers();
        }
        public List<EmployeeViewModel> GetViewModelEmployees()
        {
            return new UserDAL().GetViewModelEmployees();
        }
        public List<User> GetEmployees()
        {
            return new UserDAL().GetEmployees();
        }
        public User GetEmployee(int id)
        {
            return new UserDAL().GetEmployee(id);
        }

      
    }
}
