namespace HotelBookingSystem.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using HotelBookingSystem.Infrastructure.Common.Enums;

    public class Facility
    {
        [Key]
        public int Id { get; set; }

        public FacilitieType Type { get; set; }

        public ICollection<HotelFacility> Hotels { get; set; } = new HashSet<HotelFacility>();
    }
}
