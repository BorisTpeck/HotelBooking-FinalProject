namespace HotelBookingSystem.Controllers
{
    using HotelBookingSystem.Common.Constants;
    using HotelBookingSystem.Core.Contracts;
    using HotelBookingSystem.Core.Models.Reservation.BindingModels;
    using HotelBookingSystem.Core.Models.Reservation.ViewModels;
    using HotelBookingSystem.Core.Models.Room.ViewModels;
    using HotelBookingSystem.Infrastructure.Extenstions;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ReservationController : Controller
    {
        private readonly IReservationService reservationService;

        public ReservationController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableRooms(int hotelId, DateTime fromDate, DateTime toDate)
        {
            IEnumerable<RoomReservationListItemViewModel> availableRooms = await this.reservationService.GetAvailableRooms(hotelId, fromDate, toDate);

            return PartialView("~/Views/Shared/Partials/_AvailableRooms.cshtml", availableRooms);
        }

        [HttpGet]
        [Authorize(Roles = GlobalConstants.ClientRole)]
        public async Task<IActionResult> Mine()
        {
            IEnumerable<MineReservationViewModel> reservations = await this.reservationService.GetMine(this.User.GetClientId());

            return View(reservations);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.ClientRole)]
        public async Task<IActionResult> Create([FromBody]CreateReservationBindingModel reservationData)
        {
            await this.reservationService.Create(this.User.GetClientId(), reservationData);

            return Ok();
        }
    }
}
