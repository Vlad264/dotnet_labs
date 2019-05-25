using Microsoft.EntityFrameworkCore;

namespace EffectiveEmployee.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        
        public DbSet<Project> Projects { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }
    }
}