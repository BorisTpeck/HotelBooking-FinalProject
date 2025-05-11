namespace HotelBookingSystem.Infrastructure.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public Client? Client { get; set; }
    }
}
