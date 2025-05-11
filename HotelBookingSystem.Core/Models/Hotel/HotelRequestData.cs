namespace HotelBookingSystem.Core.Models.Hotel
{
    public class HotelRequestData
    {
        public int CurrentPage { get; set; } = 1;

        public IEnumerable<int> LocationFilter { get; set; }

        public IEnumerable<int> FacilityFilter { get; set; }
    }
}
