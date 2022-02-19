using PayrollApplication.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApplication.DAL
{
    public class AccountDAL
    {
        private readonly PayrollContext db = new PayrollContext();
        public bool CheckAdmin(string email, string password)
        {
            return db.Users.Where(x => x.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase) && x.Password.Equals(password) && x.RoleId == 1).Any();

        }

        public User GetUser(string email, string password)
        {
            return db.Users.Where(x => x.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase) && x.Password.Equals(password)).FirstOrDefault();

        }

        public User GetUser(int id)
        {
            return db.Users.Where(x => x.Id == id).FirstOrDefault();
        }

     

        public UserInfo GetUserInfo(string email, string password)
        {
            return db.Users.Where(x => x.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase) && x.Password.Equals(password)).Select(x => new UserInfo { Id = x.Id, Name = x.Name, Role = x.Role.Name, AccessToken = x.AccessToken }).FirstOrDefault();

        }
        public int GetUserRole(string AccessToken)
        {
            return db.Users.Where(x => x.AccessToken.Equals(AccessToken)).Select(x => x.RoleId).FirstOrDefault();

        }
    }
}

