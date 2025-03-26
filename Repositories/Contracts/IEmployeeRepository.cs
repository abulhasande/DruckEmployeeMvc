using DruckEmployeeMvc.Models;
using DruckEmployeeMvc.ViewModel;

namespace DruckEmployeeMvc.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        Task<EmployeeDto> CreateEmployee(EmployeeDto employee);
        Task<bool> UpdateEmployee(EmployeeDto employee);
        Task<bool> DeleteEmployee(int id);
        Task<EmployeeDto> GetEmployeeById(int id);
        Task<List<EmployeeDto>> GetEmployees();
    }
}
