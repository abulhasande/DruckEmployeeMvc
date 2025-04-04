using System.ComponentModel.DataAnnotations;

namespace DruckEmployeeMvc.ViewModel
{
    public class EmployeeDto
    {        
    
        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Department { get; set; }   

        [Required]
        public string Email { get; set; }
 
    }
}
