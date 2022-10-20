using iTechArt.Database.Entities.Airports;
using iTechArt.Database.Entities.Groceries;
using iTechArt.Database.Entities.MedicalStaff;
using iTechArt.Database.Entities.Police;
using iTechArt.Database.Entities.Pupils;
using iTechArt.Database.Entities.Students;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Database.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Airport tables
        /// </summary>
        public virtual DbSet<Airport> Airports { get; set; }


        /// <summary>
        /// Medicine staff tables
        /// </summary>
        public virtual DbSet<Doctor> Staffs { get; set; }

        /// <summary>
        /// Pupil tables
        /// </summary>
        public virtual DbSet<Pupil> Pupils { get; set; }

        /// <summary>
        /// Student tables
        /// </summary>
        public virtual DbSet<Students> Students { get; set; }

        /// <summary>
        /// Police tables
        /// </summary>
        public virtual DbSet<Police> Police { get; set; }

        /// <summary>
        /// Grocery tables
        /// </summary>
        public virtual DbSet<Grocery> Groceries { get; set; } 
    }
}
