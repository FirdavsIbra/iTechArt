using iTechArt.Domain.Entities.Airports;
using iTechArt.Domain.Entities.MedicalStaff;
using iTechArt.Domain.Entities.Pupils;
using iTechArt.Domain.Entities.Students;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Data.DbContexts
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
        public DbSet<Airport> Airports { get; set; }

        /// <summary>
        /// Medicine staff tables
        /// </summary>
        public DbSet<Patient> Patients { get; set; }

        public DbSet<PatientDoctor> PatientDoctors { get; set; }

        public DbSet<Hospital> Hospitals { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<StaffHospitalContraction> StaffHospitalContractions { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        /// <summary>
        /// Pupil tables
        /// </summary>
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<School> Schools { get; set; }

        /// <summary>
        /// Student tables
        /// </summary>
        public virtual DbSet<Student> Students { get; set; }

        /// <summary>
        /// Configure relationships
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>()
                .HasOne(s => s.Address)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
