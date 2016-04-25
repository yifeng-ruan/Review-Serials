
using Model;

namespace AccountServices
{
    public class AuthenticationService
    {
        public bool IsValidateUser(Account account)
        {
            return account.UserName=="Admin"&&account.Password=="123";
        }
    }
}
