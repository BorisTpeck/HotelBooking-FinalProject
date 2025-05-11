namespace HotelBookingSystem.Core.Models.Hotel.ViewModels
{
    using HotelBookingSystem.Core.Models.Room.ViewModels;

    public class ListHotelsRoomsViewModel
    {
        public int HotelId { get; set; }

        public string HotelName { get; set; }

        public IEnumerable<RoomListItemViewModel> Rooms { get; set; }

        public bool HasRooms => this.Rooms.Any();
    }
}
