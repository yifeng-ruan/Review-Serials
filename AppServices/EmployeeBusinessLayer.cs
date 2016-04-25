using System.Collections.Generic;
using DataAccess.Repositories;
using Model;

namespace AppServices
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            var repository =new EmployeeRepository();
            return repository.GetEmployees();
        }

        public Employee Add(Employee e)
        {
            var repository = new EmployeeRepository();
            return repository.Add(e);
        }
    }
}
