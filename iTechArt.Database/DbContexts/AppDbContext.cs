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
        /// <summary>
        /// Makes DI into DbContext
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Airport tables
        /// </summary>
        public virtual DbSet<AirportDb> Airports { get; set; }


        /// <summary>
        /// Medicine staff tables
        /// </summary>
        public virtual DbSet<DoctorDb> Staffs { get; set; }

        /// <summary>
        /// Pupil tables
        /// </summary>
        public virtual DbSet<PupilDb> Pupils { get; set; }

        /// <summary>
        /// Student tables
        /// </summary>
        public virtual DbSet<StudentDb> Students { get; set; }

        /// <summary>
        /// Police tables
        /// </summary>
        public virtual DbSet<PoliceDb> Police { get; set; }

        /// <summary>
        /// Grocery tables
        /// </summary>
        public virtual DbSet<GroceryDb> Groceries { get; set; }
    }
}
