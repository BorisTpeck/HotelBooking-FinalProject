namespace HotelBookingSystem.Controllers
{
    using HotelBookingSystem.Common.Constants;
    using HotelBookingSystem.Core.Contracts;
    using HotelBookingSystem.Core.Models.Hotel;
    using HotelBookingSystem.Core.Models.Hotel.BindingModels;
    using HotelBookingSystem.Core.Models.Hotel.ViewModels;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class HotelController : Controller
    {
        private readonly IHotelService hotelService;
        private readonly ILocationService locationService;
        private readonly IFacilityService facilityService;

        public HotelController(
            IHotelService hotelService,
            ILocationService locationService,
            IFacilityService facilityService)
        {
            this.hotelService = hotelService;
            this.locationService = locationService;
            this.facilityService = facilityService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(HotelRequestData requestData)
        {
            ListHotelsViewModel hotels = await this.hotelService.GetAllPaged(requestData);

            return View(hotels);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            HotelFormBindingModel hotel = new HotelFormBindingModel
            {
                Locations = await this.locationService.GetAll(),
                Facilities = await this.facilityService.GetAll(),
            };

            return View(hotel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(HotelFormBindingModel hotel)
        {
            if (!this.ModelState.IsValid)
            {
                hotel.Locations = await this.locationService.GetAll();
                hotel.Facilities = await this.facilityService.GetAll();

                return View(hotel);
            }

            await this.hotelService.Create(hotel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            HotelFormBindingModel hotel = await this.hotelService.GetByIdForEdit(id);

            return View(hotel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, HotelFormBindingModel hotel)
        {
            if (!this.ModelState.IsValid)
            {
                hotel.Locations = await this.locationService.GetAll();
                hotel.Facilities = await this.facilityService.GetAll();

                return View(hotel);
            }

            await this.hotelService.Edit(id, hotel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            HotelDetailsViewModel hotel = await this.hotelService.GetById(id);

            return View(hotel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await this.hotelService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
