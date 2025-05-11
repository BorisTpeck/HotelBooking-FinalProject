namespace HotelBookingSystem.Core.Models.Room.ViewModels
{
    using HotelBookingSystem.Infrastructure.Common.Enums;

    public class RoomListItemViewModel
    {
        public int Id { get; set; }

        public RoomCapacityType Capacity { get; set; }

        public decimal PricePerDay { get; set; }

        public int Number { get; set; }

        public bool HasCurrentOrFutureReservations { get; set; }
    }
}
