using DruckEmployeeMvc.Data;
using DruckEmployeeMvc.Models;
using DruckEmployeeMvc.Repositories.Contracts;
using DruckEmployeeMvc.ViewModel;

namespace DruckEmployeeMvc.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmplyeeDbContext _context;
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(ILogger<EmployeeRepository> logger, EmplyeeDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            try
            {
                var employees = _context.Employees.ToList();             
                return employees;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async  Task CreateEmployee(EmployeeDto employeeDto)
        {
 
            try
            {
                var employee = ConvertEmployeeDtoToEmployee(employeeDto);
                _context.Add(employee);
                _context.SaveChanges();

            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task DeleteEmployee(int id)
        {
            try
            {
                var employee = _context.Employees.Find(id);
                 _context.Remove(employee);
                 _context.SaveChanges(true);             

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
                
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            try
            {
                var employee = _context.Employees.Find(id);
                if (employee != null)
                {
                    return employee;
                }
                else return null; 


            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task UpdateEmployee(int empId, EmployeeDto employeeDto)
        {

            try
            {
                var employee = _context.Employees.Find(empId); 
                if(employee != null)
                {
                    employee.Position = employeeDto.Position;
                    employee.Name = employeeDto.Name;
                    employee.Department = employeeDto.Department;
                    employee.Email = employeeDto.Email;

                    _context.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }


        public Employee ConvertEmployeeDtoToEmployee(EmployeeDto employeeDto)
        {
            var employee = new Employee();
            employee.Name = employeeDto.Name;
            employee.Email = employeeDto.Email;
            employee.Department = employeeDto.Department;
            employee.Position = employeeDto.Position;

            return employee;
        }

        public  EmployeeDto ConvertEmployeeToEmployeeDto(Employee employee)
        {
            var employeeDto = new EmployeeDto();
            employeeDto.Name = employee.Name;
            employeeDto.Email = employee.Email;
            employeeDto.Department = employee.Department;
            employeeDto.Position = employee.Position;

            return employeeDto;
        }

    }
}
