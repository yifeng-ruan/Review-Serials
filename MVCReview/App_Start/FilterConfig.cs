using System.Web;
using System.Web.Mvc;
using MVCReview.Filter;

namespace MVCReview
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute(){View = "MyError"});
            filters.Add(new EmployeeExceptionFilter());
            filters.Add(new AuthorizeAttribute());
        }
    }
}