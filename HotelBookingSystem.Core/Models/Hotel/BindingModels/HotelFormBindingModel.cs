namespace HotelBookingSystem.Core.Models.Hotel.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    using HotelBookingSystem.Core.Models.Facility.ViewModels;
    using HotelBookingSystem.Core.Models.Location.ViewModels;
    using HotelBookingSystem.Infrastructure.Common;

    public class HotelFormBindingModel
    {
        [Required]
        [StringLength(DataConstants.HotelNameMaxLength)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Image Url")]
        [Required]
        [StringLength(DataConstants.HotelImageUrlMaxLength)]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(DataConstants.HotelAddressMaxLength)]
        public string Address { get; set; }

        [Display(Name = "Location")]
        [Required]
        public int SelectedLocationId { get; set; }

        public IEnumerable<LocationViewModel> Locations { get; set; } = new List<LocationViewModel>();

        public IEnumerable<int> SelectedFacilityIds { get; set; }

        public IEnumerable<FacilityViewModel> Facilities { get; set; } = new List<FacilityViewModel>();
    }
}
