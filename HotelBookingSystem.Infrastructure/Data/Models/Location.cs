namespace HotelBookingSystem.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using HotelBookingSystem.Infrastructure.Common;

    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.LocationNameMaxLength)]
        public string Name { get; set; }

        public ICollection<Hotel> Hotels { get; set; } = new HashSet<Hotel>();
    }
}
