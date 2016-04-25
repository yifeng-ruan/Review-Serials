using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.DbContexts;
using Model;

namespace DataAccess.Repositories
{
    public class EmployeeRepository
    {
        public  List<Employee> GetEmployees()
        {
            var context = new MvcReviewContext();
            
            var my = "1234";
            return context.Employees.ToList();
        }

        public async Task<Employee> Add(Employee e)
        {
            var context = new MvcReviewContext();
            
            context.Employees.Add(e);
            context.SaveChanges();
            await Task.Delay(5000);
            return e;
        }
        public void UploadEmployees(List<Employee> employees)
        {
            var context = new MvcReviewContext();
            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}
