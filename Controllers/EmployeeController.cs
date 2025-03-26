using Microsoft.AspNetCore.Mvc;

namespace DruckEmployeeMvc.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
