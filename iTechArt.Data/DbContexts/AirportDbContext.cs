using iTechArt.Domain.Entities.Airports;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.Data.DbContexts
{
    public class AirportDbContext : DbContext
    {
        public AirportDbContext(DbContextOptions<AirportDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Airplane> Airplanes { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Airport)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
