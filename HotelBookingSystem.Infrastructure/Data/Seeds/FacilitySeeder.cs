namespace HotelBookingSystem.Infrastructure.Data.Seeds
{
    using HotelBookingSystem.Infrastructure.Common.Enums;
    using HotelBookingSystem.Infrastructure.Data.Models;

    using Microsoft.EntityFrameworkCore;

    public class FacilitySeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Facility>()
                .HasData(
                    new Facility
                    {
                        Id = (int)FacilitieType.FreeWifi,
                        Type = FacilitieType.FreeWifi,
                    },
                    new Facility
                    {
                        Id = (int)FacilitieType.FreeParking,
                        Type = FacilitieType.FreeParking,
                    },
                    new Facility
                    {
                        Id = (int)FacilitieType.SwimmingPool,
                        Type = FacilitieType.SwimmingPool,
                    },
                    new Facility
                    {
                        Id = (int)FacilitieType.Spa,
                        Type = FacilitieType.Spa,
                    },
                    new Facility
                    {
                        Id = (int)FacilitieType.Gym,
                        Type = FacilitieType.Gym,
                    }
                );
        }
    }
}
