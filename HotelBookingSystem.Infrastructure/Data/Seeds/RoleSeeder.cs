namespace HotelBookingSystem.Infrastructure.Data.Seeds
{
    using HotelBookingSystem.Common.Constants;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public static class RoleSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "28aacc91-3f2d-4b60-a2ce-d6d8e4793464",
                    Name = GlobalConstants.AdminRole,
                    NormalizedName = GlobalConstants.AdminRole.ToUpper(),
                    ConcurrencyStamp = "5a51bdb8-7906-45b3-8545-66c1a675f079",
                },
                new IdentityRole
                {
                    Id = "8e590a4c-cd20-4807-b7a6-c9faa6dab69c",
                    Name = GlobalConstants.ClientRole,
                    NormalizedName = GlobalConstants.ClientRole.ToUpper(),
                    ConcurrencyStamp = "2f3e5ac9-95a4-4c44-b1c4-3ac558b8f9f8",
                }
            );
        }
    }
}
