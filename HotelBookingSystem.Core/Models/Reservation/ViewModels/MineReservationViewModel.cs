namespace HotelBookingSystem.Core.Models.Reservation.ViewModels
{
    public class MineReservationViewModel
    {
        public string HotelName { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int TotalDays => (this.ToDate - this.FromDate).Days;

        public decimal PricePerDay { get; set; }

        public decimal TotalPrice { get; set; }

        public string Location { get; set; }
    }
}
