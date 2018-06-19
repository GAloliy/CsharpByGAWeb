using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class UserStateManager
    {
        public static UserState GetDefaultUserState()
        {
            UserState userState = new UserState()
            {
                id = 1,
                name = "离线"
            };
            return userState;
        }
    }
}
