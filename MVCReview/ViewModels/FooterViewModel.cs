using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCReview.ViewModels
{
    [Serializable]
    public class FooterViewModel
    {
        public string CompanyName { get; set; }
        public string Year { get; set; }
    }
}