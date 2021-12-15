using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identify
{
    public abstract class creator
    {
        public abstract User FactoryUser(int userId, string userName, string password, string email);
    }

    public class CODCreator : creator
    {
        public override User FactoryUser(int userId, string userName, string password, string email)
        {
            return new COD(userId,userName,password,email);
        }
    }
    public class DABICreator : creator
    {
        public override User FactoryUser(int userId, string userName, string password, string email)
        {
            return new DABI(userId, userName, password, email);
        }
    }
    public class RACSCreator : creator
    {
        public override User FactoryUser(int userId, string userName, string password, string email)
        {
            return new RACS(userId, userName, password, email);
        }
    }
    public class DMSCreator : creator
    {
        public override User FactoryUser(int userId, string userName, string password, string email)
        {
            return new DMS(userId, userName, password, email);
        }
    }
}
