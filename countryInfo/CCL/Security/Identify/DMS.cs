using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identify
{
    public class DMS :User
    {
        public DMS(int userId, string userName, string password, string email)
            : base(userId, userName, password, email, nameof(DMS))
        {
        }
    }
}
