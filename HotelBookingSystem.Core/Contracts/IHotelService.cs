namespace HotelBookingSystem.Core.Contracts
{
    using HotelBookingSystem.Core.Models.Hotel;
    using HotelBookingSystem.Core.Models.Hotel.BindingModels;
    using HotelBookingSystem.Core.Models.Hotel.ViewModels;

    public interface IHotelService
    {
        Task<ListHotelsViewModel> GetAllPaged(HotelRequestData requestData);

        Task<IEnumerable<TEntity>> GetAll<TEntity>() where TEntity : class;

        Task<HotelFormBindingModel> GetByIdForEdit(int id);

        Task<HotelDetailsViewModel> GetById(int id);

        Task Create(HotelFormBindingModel hotel);

        Task Edit(int hotelId, HotelFormBindingModel hotel);

        Task Delete(int id);
    }
}
