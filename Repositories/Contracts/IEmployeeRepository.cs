using DruckEmployeeMvc.Models;
using DruckEmployeeMvc.ViewModel;

namespace DruckEmployeeMvc.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        Task CreateEmployee(EmployeeDto employee);
        Task UpdateEmployee(int id, EmployeeDto employeeDto);
        Task DeleteEmployee(int id);
        Task<Employee> GetEmployeeById(int id);
        Task<List<Employee>> GetEmployees();

        Employee ConvertEmployeeDtoToEmployee(EmployeeDto employeeDto);
        EmployeeDto ConvertEmployeeToEmployeeDto(Employee employee);

    }
}
