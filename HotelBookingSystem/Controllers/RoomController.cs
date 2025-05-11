namespace HotelBookingSystem.Controllers
{
    using HotelBookingSystem.Common.Constants;
    using HotelBookingSystem.Core.Contracts;
    using HotelBookingSystem.Core.Models.Hotel.ViewModels;
    using HotelBookingSystem.Core.Models.Room.BindingModels;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class RoomController : Controller
    {
        private readonly IRoomService roomService;
        private readonly IHotelService hotelService;

        public RoomController(IRoomService roomService, IHotelService hotelService)
        {
            this.roomService = roomService;
            this.hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<ListHotelsRoomsViewModel> hotels = await this.hotelService.GetAll<ListHotelsRoomsViewModel>();

            return View(hotels);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            RoomFormBindingModel room = new RoomFormBindingModel
            {
                Hotels = await this.hotelService.GetAll<HotelOptionViewModel>(),
            };

            return View(room);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomFormBindingModel room)
        {
            if (!this.ModelState.IsValid)
            {
                room.Hotels = await this.hotelService.GetAll<HotelOptionViewModel>();

                return View(room);
            }

            await this.roomService.Create(room);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            RoomFormBindingModel room = await this.roomService.GetByIdForEdit(id);

            return View(room);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, RoomFormBindingModel room)
        {
            if (!this.ModelState.IsValid)
            {
                room.Hotels = await this.hotelService.GetAll<HotelOptionViewModel>();

                return View(room);
            }

            await this.roomService.Edit(id, room);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await this.roomService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
