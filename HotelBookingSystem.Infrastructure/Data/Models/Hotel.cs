namespace HotelBookingSystem.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using HotelBookingSystem.Infrastructure.Common;

    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.HotelNameMaxLength)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(DataConstants.HotelImageUrlMaxLength)]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(DataConstants.HotelAddressMaxLength)]
        public string Address { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();

        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();

        public ICollection<HotelFacility> Facilities { get; set; } = new HashSet<HotelFacility>();
    }
}
