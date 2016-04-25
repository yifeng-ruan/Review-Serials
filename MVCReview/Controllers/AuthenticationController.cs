using Services;
using System.Web.Mvc;
using System.Web.Security;
using Model;
using MVCReview.ViewModels;

namespace MVCReview.Controllers
{
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult DoLogin(AccountPostViewModel account)
        {
            var service = new AuthenticationService();
            var status = service.GetUserValidity(new Account
            {
                UserName = account.Name,
                Password = account.Pwd
            });
            switch (status)
            {
                case UserStatus.AuthenticatedAdmin:
                    Session["IsAdmin"] = true;
                    break;
                case UserStatus.AuthentucatedUser:
                    Session["IsAdmin"] = false;
                    break;
                case UserStatus.NonAuthenticatedUser:
                    break;
                default:
                    ModelState.AddModelError("AddError", "Invalid Username or password!");
                    return View("Login");
            }
            FormsAuthentication.SetAuthCookie(account.Name, false);
            return RedirectToAction("Index", "User");
        }
    }
}
