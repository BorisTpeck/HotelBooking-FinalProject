namespace HotelBookingSystem.Core.MappingProfiles
{
    using HotelBookingSystem.Core.Common;
    using HotelBookingSystem.Core.Models.Facility.ViewModels;
    using HotelBookingSystem.Infrastructure.Data.Models;

    public class FacilityMappingProfile : MappingProfile
    {
        public FacilityMappingProfile()
        {
            this.CreateMap<Facility, FacilityViewModel>();
        }
    }
}
