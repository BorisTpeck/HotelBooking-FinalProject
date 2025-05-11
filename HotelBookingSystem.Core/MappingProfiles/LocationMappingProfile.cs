namespace HotelBookingSystem.Core.MappingProfiles
{
    using HotelBookingSystem.Core.Common;
    using HotelBookingSystem.Core.Models.Location.ViewModels;
    using HotelBookingSystem.Infrastructure.Data.Models;

    public class LocationMappingProfile : MappingProfile
    {
        public LocationMappingProfile()
        {
            this.CreateMap<Location, LocationViewModel>();
        }
    }
}
