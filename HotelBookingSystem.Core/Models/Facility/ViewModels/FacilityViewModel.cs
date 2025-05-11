namespace HotelBookingSystem.Core.Models.Facility.ViewModels
{
    using HotelBookingSystem.Infrastructure.Common.Enums;

    public class FacilityViewModel
    {
        public int Id { get; set; }

        public FacilitieType Type { get; set; }
    }
}
