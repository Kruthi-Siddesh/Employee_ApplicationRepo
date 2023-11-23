using Employee_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Application.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employees>> GetEmployee();

        Task<Employees> GetEmpByID(int id);

        Task<IEnumerable<Employees>> CreateEmployee(Employees emp);

        Task<Employees> UpdateEmp(int id, string name);

        Task<Employees> UpdateEmpDeatils(int id, string name);

        Task<Employees> DeleteEmp(int id);
    }
}
