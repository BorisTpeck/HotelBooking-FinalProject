namespace HotelBookingSystem.Core.Contracts
{
    using HotelBookingSystem.Core.Models.Room.BindingModels;

    public interface IRoomService
    {
        Task<RoomFormBindingModel> GetByIdForEdit(int id);

        Task Create(RoomFormBindingModel room);

        Task Edit(int id, RoomFormBindingModel room);

        Task Delete(int id);
    }
}
