using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVCReview.Controllers;

namespace MVCReview.ViewModels
{
    public class EmployeeViewModel : ReactViewModel
    {
        [Required(ErrorMessage = "Please Enter the Name")]
        [MyValidation]
        public string Name { get; set; }

        public string Salary { get; set; }

        public string SalaryColor { get; set; }
    }

    public class EmployeeListViewModel:ReactViewModel
    {
        public List<EmployeeViewModel> Employees { get; set; }
    }
}