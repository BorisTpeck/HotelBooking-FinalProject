using System.ComponentModel.DataAnnotations;

namespace HotelManeger.Infestructure.Data.Models
{
    public class Stay
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateOfStay { get; set; } = DateTime.Now;

        [Required]
        public DateTime DateOfCreation { get; set; } = DateTime.Now;

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
