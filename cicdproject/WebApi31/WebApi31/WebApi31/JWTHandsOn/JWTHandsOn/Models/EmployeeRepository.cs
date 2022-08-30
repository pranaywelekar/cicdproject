using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTHandsOn.Models
{
    public class EmployeeRepository:IEmployeeRepository
    {
        List<Employee> employees = new List<Employee>()
        {
            new Employee() {Id=101,Name="Tharun",Salary=30000,Location="Hyderabad",IsPermanent=true},
            new Employee() {Id=102,Name="Sharan",Salary=26000,Location="Chennai",IsPermanent=true},
            new Employee() {Id=103,Name="Naveen",Salary=20000,Location="Coimbatore",IsPermanent=false},             
            new Employee() {Id=104,Name="Gokul",Salary=50000,Location="Bangalore",IsPermanent=false}

        };
        public List<Employee> CreateEmployee(Employee emp)
        {
            employees.Add(emp);
            return employees;
        }

        public bool DeleteEmployee(int id)
        {
            Employee employee = employees.SingleOrDefault(e => e.Id == id);
            bool deletedstatus = employees.Remove(employee);
            return deletedstatus;

        }

        public Employee GetEmployee(int id)
        {
            Employee e = employees.SingleOrDefault(e => e.Id == id);
            if (e != null)
                return e;
            else
                return null;
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public Employee UpdateEmployee(Employee emp)
        {
            Employee e = employees.Find(e => e.Id == emp.Id);
            if (e != null)
            {
                e.Id = emp.Id;
                e.Name = emp.Name;
                e.Salary = emp.Salary;
                e.Location = emp.Location;
                e.IsPermanent = emp.IsPermanent;
                return e;
            }
            else
            {
                return null;
            }

        }
    }
}
