
using Model;

namespace Services
{
    public class AuthenticationService
    {
        public bool IsValidateUser(Account account)
        {
            return account.UserName=="Admin"&&account.Password=="123";
        }

        public UserStatus GetUserValidity(Account u)
        {
            if (u.UserName == "Admin" && u.Password == "123")
            {
                return UserStatus.AuthenticatedAdmin;
            }
            else if (u.UserName == "Ryan" && u.Password == "123")
            {
                return UserStatus.AuthentucatedUser;
            }
            else
            {
                return UserStatus.NonAuthenticatedUser;
            }
        }
    }
}
