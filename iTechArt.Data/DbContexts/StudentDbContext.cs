using iTechArt.Domain.Entities.Students;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Data.DbContexts
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
        
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<University> Universities { get; set; }
    }
}
