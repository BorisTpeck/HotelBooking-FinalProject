using Microsoft.EntityFrameworkCore;
using HotelManeger.Infestructure.Data.Models;

namespace HotelManeger.Infestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Stay> Stays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = 1,
                    Name = "Ellie",
                    FamilyName = "Foxbold",
                    PhoneNumber = "0889207652",
                    Email = "kitfoxbold.com",
                    PersonalId = "0643124520",
                    Address = "Mladost 3 blok. 18"
                }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Type = "Single", Occupied = false },
                new Room { Id = 2, Type = "Double", Occupied = false }
            );

            modelBuilder.Entity<Stay>().HasData(
                new Stay
                {
                    Id = 1,
                    DateOfStay = DateTime.Now.AddDays(1),
                    DateOfCreation = DateTime.Now,
                    ClientId = 1,
                    RoomId = 1
                }
            );
        }
    }
}
