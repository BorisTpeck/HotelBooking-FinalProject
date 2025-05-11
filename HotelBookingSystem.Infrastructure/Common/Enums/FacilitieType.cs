namespace HotelBookingSystem.Infrastructure.Common.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum FacilitieType
    {
        [Display(Name = "Free Wi-Fi")]
        FreeWifi = 1,
        [Display(Name = "Free Parking")]
        FreeParking = 2,
        [Display(Name = "Swimming Pool")]
        SwimmingPool = 3,
        Spa = 4,
        Gym = 5,
    }
}
