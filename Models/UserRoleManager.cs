using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class UserRoleManager
    {
        public static UserRole GetDefaultUserRole()
        {
            UserRole userRole = new UserRole()
            {
                id = 1,
                name = "普通用户"
            };
            return userRole;
        }
    }
}
