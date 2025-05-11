namespace HotelBookingSystem.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using HotelBookingSystem.Infrastructure.Common;

    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.ClientFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(DataConstants.ClientLastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(DataConstants.ClientPhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();
    }
}
