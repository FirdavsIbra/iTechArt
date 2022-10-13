using iTechArt.Domain.Entities.Airports;
using iTechArt.Domain.Entities.MedicalStaff;
using iTechArt.Domain.Entities.Police;
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

        ///// <summary>
        ///// Airport tables
        ///// </summary>
        //public virtual DbSet<Airport> Airports { get; set; }


        ///// <summary>
        ///// Medicine staff tables
        ///// </summary>
        //public DbSet<Doctor> Staffs { get; set; }

        ///// <summary>
        ///// Pupil tables
        ///// </summary>
        //public DbSet<Pupil> Pupils { get; set; }

        ///// <summary>
        ///// Student tables
        ///// </summary>
        //public virtual DbSet<Student> Students { get; set; }

        /// <summary>
        /// Police tables
        /// </summary>
        public DbSet<Officer> Officers { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<PhsyicalDescription> PhsyicalDescriptions { get; set; }
    }
}
