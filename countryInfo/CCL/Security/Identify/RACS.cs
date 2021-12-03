using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identify
{
    class RACS : User
    {
        public RACS(int userId, string userName, string password, string email)
            : base(userId, userName, password, email, nameof(RACS))
        {
        }
    }
}
