using System.ComponentModel.DataAnnotations;

namespace DruckEmployeeMvc.Models
{
    public class Employee
    {
        //name, position, department,
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Position { get; set; }
        [MaxLength(50)]
        public string Department { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }



    }
}
