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

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> Create(EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeDto);
            }

            await _empRepo.CreateEmployee(employeeDto);

            return RedirectToAction("Index", "Employee");
        }


        public async Task<ActionResult<EmployeeDto>> Edit(int id)
        {
            var employee = await _empRepo.GetEmployeeById(id);
            if(employee == null)
            {
                return RedirectToAction("Index", "Employee");
            }

            var employeeDto = _empRepo.ConvertEmployeeToEmployeeDto(employee);

            ViewData["Id"] = employee.Id;

            return View(employeeDto);
        }


        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> Edit(int id, EmployeeDto employeeDto)
        {
            var employee = await _empRepo.GetEmployeeById(id);
            if (employee == null)
            {
                return RedirectToAction("Index", "Employee");
            }

            if(!ModelState.IsValid)
            {
                ViewData["Id"] = employee.Id;
                return View(employeeDto);
            }

            await _empRepo.UpdateEmployee(id, employeeDto);

            return RedirectToAction("Index", "Employee");

        }

        public async Task<ActionResult> Delete(int id)
        {
            var employee = await _empRepo.GetEmployeeById(id);
            if (employee == null)
            {
                return RedirectToAction("Index", "Employee");
            }

            await _empRepo.DeleteEmployee(id);

            return RedirectToAction("Index", "Employee");

        }

    }
}
