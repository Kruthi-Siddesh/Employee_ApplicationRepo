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
            new Employees() {Id = 1, Name = "ruthi"},
            new Employees() {Id = 2, Name = "pavan"},
            new Employees() {Id = 3, Name = "vir"}
        };

        public async Task<IEnumerable<Employees>> GetEmployee()
        {
            return employees.ToList();
        }

        public async Task<Employees> GetEmpByID(int id)
        {

            var emp = employees.Find(x => x.Id == id);
            return emp;
        }
        public async Task<IEnumerable<Employees>> CreateEmployee(Employees employee)
        {
            employees.Add(employee);
            return employees.ToList();

        }

        public async Task<Employees> UpdateEmp(int id, string name)
        {
            var emp = employees.Find(x => x.Id == id);
            if (emp == null)
            {
                return null;
            }
            emp.Id = id;
            emp.Name = name;
            return emp;
        }

        public async Task<Employees> UpdateEmpDeatils(int id, string name)
        {
            var emp = employees.Find(x => x.Id == id);
            if (emp == null)
            {
                return null;
            }
            emp.Id = id;
            emp.Name = name;
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