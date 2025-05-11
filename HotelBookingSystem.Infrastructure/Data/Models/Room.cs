namespace HotelBookingSystem.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using HotelBookingSystem.Infrastructure.Common.Enums;

    public class Room
    {
        [Key]
        public int Id { get; set; }

        public RoomCapacityType Capacity { get; set; }

        public decimal PricePerDay { get; set; }

        public int Number { get; set; }

        public bool IsDeleted { get; set; }

        public int HotelId { get; set; }

        public Hotel Hotel { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
    }
}
