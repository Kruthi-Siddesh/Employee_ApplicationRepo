using Employee_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private Employees context;
        public EmployeeService(Employees context)
        {
            this.context = context;
        }
        private static List<Employees> employees = new List<Employees>()
        {
            new Employees() {Id = 1, Name = "ruthi", Address = "ckm", Salary = 1},
            new Employees() {Id = 2, Name = "pavan", Address = "tum", Salary = 2},
            new Employees() {Id = 3, Name = "vir", Address = "bang", Salary = 3}
        };

        public async Task<IEnumerable<EmployeeDto>> GetEmployee()
        {
            var employee = employees.Select(s => new EmployeeDto()
            {
                Id = s.Id,
                Name = s.Name
            });

            return employee.ToList(); ;
        }

       
          public async Task<IEnumerable<EmployeeDetailDto>> GetEmpByID(int id)
        {
           var employee = employees.Where(e=> e.Id == id).Select(s => new EmployeeDetailDto() //Method Syntax
             {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                Salary = s.Salary
             }).ToList();

            return employee;

            /* "QUERY SYNTAX"
              var employee = from e in employees
                            where e.Id == id
                            select new EmployeeDetailDto()
                            {
                                Id = e.Id,
                                Name = e.Name,
                                Address = e.Address,
                                Salary = e.Salary
                            }; 
            return employee.ToList(); */


            /* 
             "Without using LINQ (change return type to Task<EmployeeDetailDto>)"

             var emp = employees.Where(x => x.Id == id).FirstOrDefault();

             var employeeDto = new EmployeeDto
             {
               Id = emp.Id,
               Name = emp.Name
             };
             return employeeDto;*/

            //we can perform same for Employees and EmployeeDto by changing the return type.

        }

        public async Task<IEnumerable<Employees>> CreateEmployee(Employees employee)
        {
            employees.Add(employee);
            return employees.ToList();

        }

        public async Task<Employees> UpdateEmp(int id, Employees employee)
        {
            var emp = employees.Find(x => x.Id == id);
            if (emp == null)
            {
                return null;
            }
            emp.Id = id;
            emp.Name = employee.Name;
            emp.Address = employee.Address;
            emp.Salary = employee.Salary;
            return emp;
        }

        public async Task<Employees> UpdatePartOfEmp(int id, Employees employee)
        {
            var emp = employees.Find(x => x.Id == id);
            if (emp == null)
            {
                return null;
            }
            emp.Id = id;
            emp.Name = employee.Name ?? emp.Name;
            emp.Address = employee.Address ?? emp.Address; // " ?? null-coalescing operator"
            emp.Salary = employee.Salary != null ? employee.Salary : emp.Salary; // " ?: Ternary operator"
            return emp;
        }

        public async Task<Employees> DeleteEmp(int id)
        {
            var emp = employees.Find(x => x.Id == id);
            employees.Remove(emp);
            return emp;


        }
    }
}