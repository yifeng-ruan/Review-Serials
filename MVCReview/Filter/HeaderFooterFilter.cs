using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using MVCReview.ViewModels;

namespace MVCReview.Filter
{
    public class HeaderFooterFilter :ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var v = filterContext.Result as ViewResult;
            if (v!=null)
            {
                var rvm = v.Model as ReactViewModel;
                if (rvm!=null)
                {
                    rvm.UserName = "Ryan's filter";
                    rvm.FooterData = new FooterViewModel
                    {
                        CompanyName = "Ryan's Filter Co",
                        Year = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture)
                    };
                }
            }
            base.OnActionExecuted(filterContext);
        }
    }
}