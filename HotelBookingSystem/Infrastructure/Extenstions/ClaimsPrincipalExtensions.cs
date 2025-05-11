namespace HotelBookingSystem.Infrastructure.Extenstions
{
    using System.Security.Claims;

    using HotelBookingSystem.Common.Constants;

    public static class ClaimsPrincipalExtensions
    {
        public static int GetClientId(this ClaimsPrincipal claimsPrincipal)
            => int.Parse(claimsPrincipal.FindFirst(GlobalConstants.ClientIdClaim)?.Value);
    }
}
