using ATTWOOLSCHOOL.Models.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace ATTWOOLSCHOOL.EmployeeDbContext
   
{
    public class AttwoolDbbContext : DbContext
    {
        public AttwoolDbbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
 