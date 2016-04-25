using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Account
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public enum UserStatus
    {
        AuthenticatedAdmin,
        AuthentucatedUser,
        NonAuthenticatedUser
    }
}
