using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCore_2_version.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees;

        public EmployeeRepository()
        {
            _employees = new List<Employee>()
            {
                new Employee(){Id = 1,Name = "John",Email ="john@gmail.com",Department = Dept.HR },
                new Employee(){Id = 2,Name = "Mary",Email ="mary@gmail.com",Department = Dept.Sales },
                new Employee(){Id = 3,Name = "Adward",Email ="adward@gmail.com",Department = Dept.IT },
                new Employee(){Id = 4,Name = "Tom",Email ="tom@gmail.com",Department = Dept.HR}
            };
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employees;
        }

        public Employee GetEmployee(int Id)
        {
            return _employees.FirstOrDefault(emp => emp.Id == Id);
        }
    }
}
