namespace HotelBookingSystem.Core.Models.Hotel.ViewModels
{
    using HotelBookingSystem.Infrastructure.Common.Enums;

    public class HotelListItemViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Location { get; set; }

        public bool HasActiveReservations { get; set; }

        public IEnumerable<FacilitieType> Facilities { get; set; }
    }
}
