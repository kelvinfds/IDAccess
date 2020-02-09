using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAccess.Interfaces.Users
{
    public class HashAdmin
    {
        public string password;

        public HashAdmin() { }
    }

    public class PassSalt
    {
        public string password;
        public string salt;
    }
}
