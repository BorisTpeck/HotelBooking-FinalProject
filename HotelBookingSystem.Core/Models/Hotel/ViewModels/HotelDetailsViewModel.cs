using HotelBookingSystem.Infrastructure.Common.Enums;

namespace HotelBookingSystem.Core.Models.Hotel.ViewModels
{
    public class HotelDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Location { get; set; }

        public string Address { get; set; }

        public IEnumerable<FacilitieType> Facilities { get; set; }
    }
}
