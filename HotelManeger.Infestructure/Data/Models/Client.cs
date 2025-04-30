using System.ComponentModel.DataAnnotations;

namespace HotelManeger.Infestructure.Data.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string FamilyName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PersonalId { get; set; }

        [Required]
        public string Address { get; set; }

        public ICollection<Stay> Stays { get; set; } = new List<Stay>();
    }
}
