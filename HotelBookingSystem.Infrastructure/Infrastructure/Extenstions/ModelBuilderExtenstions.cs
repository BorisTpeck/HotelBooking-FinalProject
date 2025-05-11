namespace HotelBookingSystem.Infrastructure.Infrastructure.Extenstions
{
    using HotelBookingSystem.Infrastructure.Data.Seeds;

    using Microsoft.EntityFrameworkCore;

    public static class ModelBuilderExtenstions
    {
        public static void SeedData(this ModelBuilder builder)
        {
            FacilitySeeder.Seed(builder);
            LocationSeeder.Seed(builder);
            RoleSeeder.Seed(builder);
        }
    }
}
