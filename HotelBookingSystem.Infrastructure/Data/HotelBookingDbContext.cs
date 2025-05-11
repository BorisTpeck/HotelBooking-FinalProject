namespace HotelBookingSystem.Infrastructure.Data
{
    using HotelBookingSystem.Infrastructure.Data.Models;
    using HotelBookingSystem.Infrastructure.Infrastructure.Extenstions;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class HotelBookingDbContext : IdentityDbContext<User>
    {
        public HotelBookingDbContext(DbContextOptions<HotelBookingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Facility> Facilities { get; set; }

        public DbSet<HotelFacility> HotelFacilites { get; set; }

        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            builder.Entity<Hotel>().HasQueryFilter(h => !h.IsDeleted);
            builder.Entity<Room>().HasQueryFilter(r => !r.IsDeleted);

            builder.SeedData();
        }
    }
}
