﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCL.Security.Identify;

namespace CCL.Security
{
    public class SecurityContext
    {
        static User _user = null;

        public static User GetUser()
        {
            return _user;
        }

        public static void SetUser(User user)
        {
            _user = user;
        }
    }
}
