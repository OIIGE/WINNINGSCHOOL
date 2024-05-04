using Microsoft.EntityFrameworkCore;
using WINNINGSCHOOL.Models.DbEntities;

namespace WINNINGSCHOOL.AttwoolContext

{
    public class WinningSchoolDbbContext : DbContext
    {
        public WinningSchoolDbbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
 