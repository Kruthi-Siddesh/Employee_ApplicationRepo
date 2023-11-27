using Employee_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Application.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDetailDto>> GetEmployee();

        Task<EmployeeDetailDto> GetEmpByID(int id);

        /* Depending on the requirements we can define methods
         * Task<IEnumerable<EmployeeDetailDto>> GetEmpByID(int id);
         * Task<IEnumerable<Employees>> GetEmpByID(int id); */

        Task<EmployeeDetailDto> CreateEmployee(EmployeeDetailDto employee);

        Task<EmployeeDetailDto> UpdateEmp(int id, EmployeeDetailDto employee);

        Task<EmployeeDetailDto> UpdatePartOfEmp(int id, EmployeeDetailDto employee);

        Task<string> DeleteEmp(int id);
    }
}
