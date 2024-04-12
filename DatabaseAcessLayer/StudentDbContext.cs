using ATTWOOLSCHOOL.Models.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace ATTWOOLSCHOOL.DatabaseAcessLayer
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
    }
}
