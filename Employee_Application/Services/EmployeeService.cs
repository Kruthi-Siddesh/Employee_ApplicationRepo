using Employee_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        /* Use whenn you have specific requirements
        private Employees context;
        public EmployeeService(Employees context)
        {
            this.context = context;
        }
        */
        private static List<Employees> employees = new List<Employees>()
        {
            new Employees() {Id = 1, Name = "ruthi", Address = "ckm", Salary = 1},
            new Employees() {Id = 2, Name = "pavan", Address = "tum", Salary = 2},
            new Employees() {Id = 3, Name = "vir", Address = "bang", Salary = 3}
        };

        private EmployeeDetailDto MapToDTO(Employees employee)
        {
            return new EmployeeDetailDto
            {
                Name = employee.Name,
                Address = employee.Address,
                Salary = employee.Salary
            };
        }

        public async Task<IEnumerable<EmployeeDetailDto>> GetEmployee()
        {
            /* Without using DTO
             var employee = employees.FirstOrDefault();
             return employee;
            */
            var employee = employees.Select(e => MapToDTO(e));

            return await Task.FromResult(employee);
        }
 
          public async Task<EmployeeDetailDto> GetEmpByID(int id)
        {
            var employee = employees.Where(e => e.Id == id).FirstOrDefault();
            if (employee == null)
            {
                return null;
            }

            return await Task.FromResult(MapToDTO(employee));

        }

        public async Task<EmployeeDetailDto> CreateEmployee(EmployeeDetailDto employee)
        {
            var emp = new Employees
            {
                Id = employees.Count + 1,
                Name = employee.Name,
                Address = employee.Address,
                Salary = employee.Salary
            };

            employees.Add(emp);
            return await Task.FromResult(MapToDTO(emp));

        }
        public async Task<EmployeeDetailDto> UpdateEmp(int id, EmployeeDetailDto employee)
        {
            var emp = employees.FirstOrDefault(x => x.Id == id);
            if (emp != null)
            {
                emp.Name = employee.Name;
                emp.Address = employee.Address;
                emp.Salary = employee.Salary;

                return await Task.FromResult(MapToDTO(emp));
            }
            else
            {
                return null;
            }
        }

        public async Task<EmployeeDetailDto> UpdatePartOfEmp(int id, EmployeeDetailDto employee)
        {
            var emp = employees.Find(x => x.Id == id);
            if (emp != null)
            {
                emp.Name = employee.Name ?? emp.Name;
                emp.Address = employee.Address ?? emp.Address; // " ?? null-coalescing operato
                emp.Salary = employee.Salary != null ? employee.Salary : emp.Salary; // " ?: Ternary operator"
                return await Task.FromResult(MapToDTO(emp));
            }
            else
            {
                return null;
            }
      
        }

        public async Task<string> DeleteEmp(int id)
        {
            var emp = employees.Find(x => x.Id == id);
            if (emp != null)
            {
                employees.Remove(emp);
                return await Task.FromResult("Employee deleted successfully");
            }
            else
            {
                return await Task.FromResult("Employee ID does not exist");
            }

        }
    }
}