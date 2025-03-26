using System.ComponentModel.DataAnnotations;

namespace DruckEmployeeMvc.ViewModel
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }    
        public string? Department { get; set; }     
        public string? Email { get; set; }
    }
}
