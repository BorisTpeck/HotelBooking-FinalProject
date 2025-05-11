namespace HotelBookingSystem.Core.Contracts
{
    using HotelBookingSystem.Core.Models.Reservation.BindingModels;
    using HotelBookingSystem.Core.Models.Reservation.ViewModels;
    using HotelBookingSystem.Core.Models.Room.ViewModels;

    public interface IReservationService
    {
        Task<IEnumerable<RoomReservationListItemViewModel>> GetAvailableRooms(int hotelId, DateTime fromDate, DateTime toDate);

        Task<IEnumerable<MineReservationViewModel>> GetMine(int clientId);

        Task Create(int clientId, CreateReservationBindingModel reservationData);
    }
}
