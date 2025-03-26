using DruckEmployeeMvc.Repositories.Contracts;
using DruckEmployeeMvc.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DruckEmployeeMvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _empRepo;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _empRepo = employeeRepository;
        }

        public async Task<ActionResult<List<EmployeeDto>>> Index()
        {
            var employees = await _empRepo.GetEmployees();
            return View(employees);
        }

        public async Task<ActionResult<EmployeeDto>> Create()
        {

            return View();
        }
    }
}
