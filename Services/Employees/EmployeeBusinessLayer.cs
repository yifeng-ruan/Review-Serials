using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Repositories;
using Model;

namespace Services
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            var repository = new EmployeeRepository();
            return  repository.GetEmployees();
        }

        public async Task<Employee> Add(Employee e)
        {
            var repository = new EmployeeRepository();
            return await repository.Add(e);
        }

        public void UploadEmployees(List<Employee> employees)
        {
            var repository = new EmployeeRepository();
            repository.UploadEmployees(employees);
        }
    }
}
