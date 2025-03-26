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

        public async Task<List<EmployeeDto>> GetEmployees()
        {
            try
            {
                var employeeDtos = new List<EmployeeDto>();
                var employees = _context.Employees.ToList();
                if(employees.Count > 0)
                {
                    foreach (var employee in employees)
                    {
                        var empDto = ConvertEmployeeToEmployeeDto(employee);
                        employeeDtos.Add(empDto);
                    }
                }

                return employeeDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async  Task<EmployeeDto> CreateEmployee(EmployeeDto employeeDto)
        {
 
            try
            {
                var employee = ConvertEmployeeDtoToEmployee(employeeDto);
                _context.Add(employee);
                var result = _context.SaveChanges();

                if (result > 0)
                    return employeeDto;
                else return null;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            try
            {
                var employee = _context.Employees.Where( x => x.Id == id);
                 _context.Remove(employee);
                var result = _context.SaveChanges();
                
                return result > 0 ? true : false;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
                
            }
        }

        public async Task<EmployeeDto> GetEmployeeById(int id)
        {
            try
            {
                var employee = _context.Employees.Where(x => x.Id == id).FirstOrDefault();
                var empDto = ConvertEmployeeToEmployeeDto(employee);
                return empDto;

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async  Task<bool> UpdateEmployee(EmployeeDto employeeDto)
        {
            int updated = 0;
            try
            {
                var employee = _context.Employees.Where(x => x.Id == employeeDto.Id).FirstOrDefault();
                if(employee != null)
                {
                    employee.Position = employeeDto.Position;
                    employee.Name = employeeDto.Name;
                    employee.Department = employeeDto.Department;
                    employee.Email = employeeDto.Email;

                    updated = _context.SaveChanges();

                }

                return updated > 0 ? true : false;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }


        private Employee ConvertEmployeeDtoToEmployee(EmployeeDto employeeDto)
        {
            var employee = new Employee();
            var maxId = (_context.Employees.Select(x => (int?)x.Id).Max() ?? 0) + 1;
            employee.Name = employeeDto.Name;
            employee.Email = employeeDto.Email;
            employee.Department = employeeDto.Department;
            employee.Position = employeeDto.Position;

            return employee;
        }

        private EmployeeDto ConvertEmployeeToEmployeeDto(Employee employee)
        {
            var employeeDto = new EmployeeDto();
            employeeDto.Id = employee.Id;
            employeeDto.Name = employee.Name;
            employeeDto.Email = employee.Email;
            employeeDto.Department = employee.Department;
            employeeDto.Position = employee.Position;

            return employeeDto;
        }

    }
}
