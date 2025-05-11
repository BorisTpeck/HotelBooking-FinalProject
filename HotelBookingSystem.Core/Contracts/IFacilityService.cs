namespace HotelBookingSystem.Core.Contracts
{
    using HotelBookingSystem.Core.Models.Facility.ViewModels;

    public interface IFacilityService
    {
        Task<IEnumerable<FacilityViewModel>> GetAll();
    }
}
