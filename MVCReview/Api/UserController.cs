using  System.Web.Http;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Providers.Entities;
using Model;
using MVCReview.ViewModels;
using Services;

namespace MVCReview.Api
{
    public class UserController : ApiController
    {
        public  IHttpActionResult Read()
        {
            var employeeListViewModel = new EmployeeListViewModel();

            var empBal = new EmployeeBusinessLayer();
            var employees =  empBal.GetEmployees();

            var empViewModels = employees.Select(emp => new EmployeeViewModel
            {
                Name = emp.Name,
                Salary = emp.Salary.ToString(),
                SalaryColor = emp.Salary > 15000 ? "yellow" : "green"
            }).ToList();

            employeeListViewModel.Employees = empViewModels;
            employeeListViewModel.UserName = User.Identity.Name;
            return Ok(employees);
        }
        public async Task<IHttpActionResult> Create(EmployeeViewModel user)
        {
            var empBal = new EmployeeBusinessLayer();
            decimal salary = 0;
            decimal.TryParse(user.Salary, out salary);
            await empBal.Add(new Employee
            {
                Name = user.Name,
                Salary = salary
            });
            return Created("api/User/" + user.Name, user);
        }
    }
}
