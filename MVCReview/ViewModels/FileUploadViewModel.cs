using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace MVCReview.ViewModels
{
    public class FileUploadViewModel:ReactViewModel
    {
        public HttpPostedFileBase fileUpload { get; set; }
    }
}