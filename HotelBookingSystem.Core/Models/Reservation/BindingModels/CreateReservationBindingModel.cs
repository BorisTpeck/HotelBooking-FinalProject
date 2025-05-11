namespace HotelBookingSystem.Core.Models.Reservation.BindingModels
{
    public class CreateReservationBindingModel
    {
        public int HotelId { get; set; }

        public int RoomId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }
    }
}
