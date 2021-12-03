using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identify
{
    public abstract class User
    {
        public User(int userId, string userName, string password, string email, string userType)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
            Email = email;
            UserType = userType;
        }
        public int UserId { get; }
        public string UserName { get; }
        public string Password { get; }
        public string Email { get; }
        protected string UserType { get; }
    }
}
