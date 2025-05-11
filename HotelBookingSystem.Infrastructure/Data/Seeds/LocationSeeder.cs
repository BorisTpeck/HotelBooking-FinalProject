namespace HotelBookingSystem.Infrastructure.Data.Seeds
{
    using HotelBookingSystem.Infrastructure.Data.Models;

    using Microsoft.EntityFrameworkCore;

    public static class LocationSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Location>()
                .HasData(
                    new Location { Id = 1, Name = "Sofia"},
                    new Location { Id = 2, Name = "Varna" },
                    new Location { Id = 3, Name = "Plovdiv" },
                    new Location { Id = 4, Name = "Veliko Turnovo" },
                    new Location { Id = 5, Name = "Bansko" },
                    new Location { Id = 6, Name = "Obzor" },
                    new Location { Id = 7, Name = "Pomorie" }
                );
        }
    }
}
