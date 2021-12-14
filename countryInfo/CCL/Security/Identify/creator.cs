using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identify
{
    abstract class creator
    {
        public abstract User FactoryUser(int userId, string userName, string password, string email);
    }

    class CODCreator : creator
    {
        public override User FactoryUser(int userId, string userName, string password, string email)
        {
            return new COD(userId,userName,password,email);
        }
    }
}
