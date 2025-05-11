namespace HotelBookingSystem.Core.Infrastructure.Extenstions
{
    using HotelBookingSystem.Core.Contracts;
    using HotelBookingSystem.Core.Implementation;

    using Microsoft.Extensions.DependencyInjection;

    public static class IServiceCollectionExtenstions
    {
        public static IServiceCollection AddCoreInfrastructure(this IServiceCollection services)
        {
            services
                .RegisterServices();

            return services;
        }

        private static IServiceCollection RegisterServices(this IServiceCollection services) 
        {
            services.AddTransient<IHotelService, HotelService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IReservationService, ReservationService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IFacilityService, FacilityService>();

            return services;
        }
    }
}
