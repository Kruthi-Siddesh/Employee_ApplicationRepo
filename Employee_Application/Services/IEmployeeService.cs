using Employee_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Application.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployee();

        Task<IEnumerable<EmployeeDetailDto>> GetEmpByID(int id);

        /* Depending on the requirements we can define methods
         * Task<IEnumerable<EmployeeDetailDto>> GetEmpByID(int id);
         * Task<IEnumerable<EmployeeDDto>> GetEmpByID(int id);
         * Task<IEnumerable<Employees>> GetEmpByID(int id); */

        Task<IEnumerable<Employees>> CreateEmployee(Employees employee);

        Task<Employees> UpdateEmp(int id, Employees employee);

        Task<Employees> UpdatePartOfEmp(int id, Employees employee);

        Task<Employees> DeleteEmp(int id);
    }
}
