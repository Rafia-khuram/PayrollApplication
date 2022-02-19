using PayrollApplication.BOL;
using PayrollApplication.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApplication.BAL
{
    
        public class AccountBAL
        {
            public bool CheckAdmin(string email, string password)
            {
                return new AccountDAL().CheckAdmin(email, password);
            }

            public User GetUser(string email, string password)
            {
                return new AccountDAL().GetUser(email, password);

            }

            public User GetUser(int id)
            {
                return new AccountDAL().GetUser(id);
            }

          
            public UserInfo GetUserInfo(string email, string password)
            {
                return new AccountDAL().GetUserInfo(email, password);

            }
            public int GetUserRole(string AccessToken)
            {
                return new AccountDAL().GetUserRole(AccessToken);
            }
        }
    }

