namespace HotelBookingSystem.Core.Models.Hotel.ViewModels
{
    using HotelBookingSystem.Core.Models.Facility.ViewModels;
    using HotelBookingSystem.Core.Models.Location.ViewModels;

    public class ListHotelsViewModel
    {
        public IEnumerable<HotelListItemViewModel> Hotels { get; set; }

        public IEnumerable<LocationViewModel> Locations { get; set; }

        public IEnumerable<FacilityViewModel> Facilities { get; set; }

        public IEnumerable<int> LocationFilter { get; set; }

        public IEnumerable<int> FacilityFilter { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalCount / this.PageSize);

        public bool HasPreviousPage => this.CurrentPage > 1;

        public bool HasNextPage => this.CurrentPage < this.TotalPages;
    }
}
