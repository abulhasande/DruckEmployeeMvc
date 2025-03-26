using DruckEmployeeMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace DruckEmployeeMvc.Data
{
    public class EmplyeeDbContext : DbContext
    {
        public EmplyeeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
