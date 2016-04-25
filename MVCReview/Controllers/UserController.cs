using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

using Model;
using MVCReview.Filter;
using MVCReview.ViewModels;
using Services;

namespace MVCReview.Controllers
{
    public class MyValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) // Checking for Empty Value
            {
                return new ValidationResult("Please Provide First Name");
            }
            else
            {
                if (value.ToString().Contains("@"))
                {
                    return new ValidationResult("First Name should Not contain @");
                }
            }
            return ValidationResult.Success;
        }
    }

    public class UserController : Controller
    {
        //
        // GET: /User/
        [Authorize]
        [HeaderFooterFilter]
        [Route("User/MyPage")]
        public ViewResult Index()
        {
            return View("Index", GetViewModel());
        }
        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult Add(EmployeeViewModel evm)
        {
            if (evm.FooterData ==null|| string.IsNullOrEmpty(evm.UserName))
            {
                evm = new EmployeeViewModel
                {
                    //FooterData = new FooterViewModel()
                    //{
                    //    CompanyName = "Ryan's Company",
                    //    Year = "2016-04-01"
                    //},
                    UserName = User.Identity.Name
                };
            }
           
            return View("Add", evm);
        }

        public ActionResult GetAddNewLink()
        {
            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                return PartialView("AddNewLink");
            }
            return new EmptyResult();
        }
        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult Save(EmployeeViewModel e, string BtnSubmit)
        {
            
            switch (BtnSubmit)
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        decimal salary = 0;
                        decimal.TryParse(e.Salary, out salary);
                        Task.Run(async () =>
                        {
                            var empBal = new EmployeeBusinessLayer();
                            await empBal.Add(new Employee
                            {
                                Name = e.Name,
                                Salary = salary
                            });
                            
                        });
                        
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        var evm = new EmployeeViewModel
                        {
                            //FooterData = new FooterViewModel()
                            //{
                            //    CompanyName = "Ryan's New Company",
                            //    Year = DateTime.Now.Year.ToString()
                            //},
                            UserName = "Ryan's"
                        };
                        return RedirectToAction("Add",evm);
                    }
                default:
                    return RedirectToAction("Index");
            }
        }

        public List<Employee> AsyncGet()
        {
            List<Employee> employees = null;
            var empBal = new EmployeeBusinessLayer();
            employees =  empBal.GetEmployees();
            return employees;
        }

        private  EmployeeListViewModel GetViewModel()
        {
            var employeeListViewModel = new EmployeeListViewModel();
            var employees = AsyncGet();
            var empViewModels = employees.Select(emp => new EmployeeViewModel
            {
                Name = emp.Name,
                Salary = emp.Salary.ToString(),
                SalaryColor = emp.Salary > 15000 ? "yellow" : "green"
            }).ToList();

            employeeListViewModel.Employees = empViewModels;
            employeeListViewModel.UserName = User.Identity.Name;
            //employeeListViewModel.FooterData = new FooterViewModel
            //{
            //    CompanyName = "Ryan",
            //    Year = DateTime.Now.Year.ToString()
            //};
            //Can be set to dynamic value
            return employeeListViewModel;
        }
    }
}
