namespace HotelBookingSystem.Core.Contracts
{
    using HotelBookingSystem.Core.Models.Location.ViewModels;

    public interface ILocationService
    {
        Task<IEnumerable<LocationViewModel>> GetAll();
    }
}
