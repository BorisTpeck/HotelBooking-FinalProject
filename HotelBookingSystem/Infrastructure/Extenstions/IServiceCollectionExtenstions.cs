namespace HotelBookingSystem.Infrastructure.Extenstions
{
    using HotelBookingSystem.Core.Common;
    using HotelBookingSystem.Infrastructure.Data;
    using HotelBookingSystem.Infrastructure.Data.Models;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public static class IServiceCollectionExtenstions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<HotelBookingDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                .AddDefaultIdentity<User>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<HotelBookingDbContext>();

            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
