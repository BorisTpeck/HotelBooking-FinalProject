namespace HotelBookingSystem.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public int HotelId { get; set; }

        public Hotel Hotel { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
