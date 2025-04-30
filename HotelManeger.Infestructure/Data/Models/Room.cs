using System.ComponentModel.DataAnnotations;

namespace HotelManeger.Infestructure.Data.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public bool Occupied { get; set; }

        public ICollection<Stay> Stays { get; set; } = new List<Stay>();
    }
}
