using iTechArt.Domain.Entities.MedicalStaff;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Data.DbContexts
{
    public class MedStaffDbContext : DbContext
    {
        public MedStaffDbContext(DbContextOptions<MedStaffDbContext> options) : base(options)
        {
        }

        public DbSet<Assistant> Assistants { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Hospital> Hospitals { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Salary> Salaries { get; set; }

        public DbSet<Staff> Staffs { get; set; }
    }
}
