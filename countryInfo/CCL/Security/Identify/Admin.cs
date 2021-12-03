using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identify
{
    public class Admin 
        : User
    {
        public Admin(int userId, string userName, string password, string email)
            : base(userId, userName, password, email, nameof(Admin))
        {
        }
    }
}
