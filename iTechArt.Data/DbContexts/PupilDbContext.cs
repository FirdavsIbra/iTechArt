using iTechArt.Domain.Entities.Pupils;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Data.DbContexts
{
    public class PupilDbContext : DbContext
    {
        public PupilDbContext(DbContextOptions<PupilDbContext> options) : base(options) { }

        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<School> Schools { get; set; }
    }
}
