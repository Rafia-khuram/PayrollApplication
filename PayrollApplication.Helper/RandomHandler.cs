using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApplication.Helper
{
   
        public static class RandomHandler
        {
            private static Random random = new Random();

            public static string GenerateAccessToken()
            {
                const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
                return new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(s.Length)]).ToArray()) + DateTime.Now.Ticks;
            }

        }

    
}
