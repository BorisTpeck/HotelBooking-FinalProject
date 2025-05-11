namespace HotelBookingSystem.Core.Models.Room.ViewModels
{
    using HotelBookingSystem.Infrastructure.Common.Enums;

    public class RoomReservationListItemViewModel
    {
        public int Id { get; set; }

        public RoomCapacityType Capacity { get; set; }

        public decimal PricePerDay { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
