using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRespository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRespository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Nirmi", Department = Dept.RS, Email = "nnawal2@uic.edu" },
                new Employee() { Id = 2, Name = "Kalyani", Department = Dept.Student, Email = "nnawal2@uic.edu" },
                new Employee() { Id = 3, Name = "Apurva", Department = Dept.Data, Email = "nnawal2@uic.edu" },
                new Employee() { Id = 1, Name = "Kajol", Department = Dept.Student, Email = "nnawal2@uic.edu" }
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == id);
            if(employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault<Employee>(e => e.Id == Id);

        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
            }
            return employee;
        }
    }
}
