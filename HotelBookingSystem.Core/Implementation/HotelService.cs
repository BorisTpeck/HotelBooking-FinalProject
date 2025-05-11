namespace HotelBookingSystem.Core.Implementation
{
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using HotelBookingSystem.Core.Common;
    using HotelBookingSystem.Core.Contracts;
    using HotelBookingSystem.Core.Models.Facility.ViewModels;
    using HotelBookingSystem.Core.Models.Hotel;
    using HotelBookingSystem.Core.Models.Hotel.BindingModels;
    using HotelBookingSystem.Core.Models.Hotel.ViewModels;
    using HotelBookingSystem.Core.Models.Location.ViewModels;
    using HotelBookingSystem.Infrastructure.Data;
    using HotelBookingSystem.Infrastructure.Data.Models;

    using Microsoft.EntityFrameworkCore;

    public class HotelService : BaseService, IHotelService
    {
        private int EntitiesPerPage = 6;

        private readonly ILocationService locationService;
        private readonly IFacilityService facilityService;

        public HotelService(
            HotelBookingDbContext dbContext, 
            IMapper mapper,
            ILocationService locationService,
            IFacilityService facilityService) 
            : base(dbContext, mapper)
        {
            this.locationService = locationService;
            this.facilityService = facilityService;
        }

        public async Task<ListHotelsViewModel> GetAllPaged(HotelRequestData requestData)
        {
            IQueryable<Hotel> hotelsQuery = this.dbContext.Hotels
                .AsQueryable();

            if (requestData.LocationFilter != null && requestData.LocationFilter.Any())
            {
                hotelsQuery = hotelsQuery
                    .Where(x => requestData.LocationFilter.Contains(x.LocationId));
            }

            if (requestData.FacilityFilter != null && requestData.FacilityFilter.Any())
            {

               hotelsQuery = hotelsQuery
                    .Where(x => x.Facilities
                        .Any(hf => requestData.FacilityFilter.Contains(hf.FacilityId)));
            }

            int totalHotels = hotelsQuery.Count();

            IEnumerable<HotelListItemViewModel> hotels = await hotelsQuery
                .OrderByDescending(x => x.Id)
                .Skip((requestData.CurrentPage - 1) * this.EntitiesPerPage)
                .Take(this.EntitiesPerPage)
                .ProjectTo<HotelListItemViewModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();

            IEnumerable<LocationViewModel> locations = await this.dbContext.Locations
                .ProjectTo<LocationViewModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();

            IEnumerable<FacilityViewModel> facilities = await this.dbContext.Facilities
                .ProjectTo<FacilityViewModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();

            ListHotelsViewModel listHotelsViewModel = new ListHotelsViewModel()
            {
                Hotels = hotels,
                CurrentPage = requestData.CurrentPage,
                PageSize = this.EntitiesPerPage,
                TotalCount = totalHotels,
                Locations = locations,
                Facilities = facilities,
                LocationFilter = requestData?.LocationFilter,
                FacilityFilter = requestData?.FacilityFilter,
            };

            return listHotelsViewModel;
        }

        public async Task<IEnumerable<TEntity>> GetAll<TEntity>() 
            where TEntity : class
        {
            IEnumerable<TEntity> hotels = await this.dbContext.Hotels
                .ProjectTo<TEntity>(this.mapper.ConfigurationProvider)
                .ToListAsync();

            return hotels;
        }

        public async Task<HotelFormBindingModel> GetByIdForEdit(int id)
        {
            HotelFormBindingModel hotel = await this.dbContext.Hotels
                .Where(x => x.Id == id)
                .ProjectTo<HotelFormBindingModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync()
                ?? throw new InvalidOperationException("Hotel not found");

            hotel.Locations = await this.locationService.GetAll();
            hotel.Facilities = await this.facilityService.GetAll();

            return hotel;
        }

        public async Task<HotelDetailsViewModel> GetById(int id)
        {
            HotelDetailsViewModel hotel = await this.dbContext.Hotels
                .Where(x => x.Id == id)
                .ProjectTo<HotelDetailsViewModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync()
                ?? throw new InvalidOperationException("Hotel not found");

            return hotel;
        }

        public async Task Create(HotelFormBindingModel hotel)
        {
            Hotel hotelToCreate = new Hotel()
            {
                Name = hotel.Name,
                Description = hotel.Description,
                ImageUrl = hotel.ImageUrl,
                Address = hotel.Address,
                LocationId = hotel.SelectedLocationId,
                Facilities = hotel.SelectedFacilityIds
                    .Select(facilityId => new HotelFacility 
                    { 
                        FacilityId = facilityId
                    })
                    .ToList(),
            };

            this.dbContext.Hotels.Add(hotelToCreate);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task Edit(int hotelId, HotelFormBindingModel hotel)
        {
            Hotel hotelToEdit = await this.dbContext.Hotels
                .Where(x => x.Id == hotelId)
                .Include(x => x.Facilities)
                .FirstOrDefaultAsync() 
                ?? throw new InvalidOperationException("Hotel not found");

            hotelToEdit.Name = hotel.Name;
            hotelToEdit.Description = hotel.Description;
            hotelToEdit.ImageUrl = hotel.ImageUrl;
            hotelToEdit.Address = hotel.Address;
            hotelToEdit.LocationId = hotel.SelectedLocationId;
            hotelToEdit.Facilities = hotel.SelectedFacilityIds
                .Select(facilityId => new HotelFacility 
                { 
                    FacilityId = facilityId
                })
                .ToList();

            this.dbContext.Hotels.Update(hotelToEdit);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            bool hasActiveReservation = await this.dbContext.Reservations
                .AnyAsync(x => x.HotelId == id && x.ToDate > DateTime.Today);

            if (hasActiveReservation)
            {
                throw new InvalidOperationException("Hotel has active reservations");
            }

            if (!await this.dbContext.Hotels.AnyAsync(x => x.Id == id))
            {
                throw new InvalidOperationException("Hotel not found");
            }

            Hotel hotelToDelete = await this.dbContext.Hotels
                .Where(x => x.Id == id)
                .Include(x => x.Rooms)
                .FirstOrDefaultAsync();

            hotelToDelete.IsDeleted = true;
            hotelToDelete.Rooms
                .ToList()
                .ForEach(x => x.IsDeleted = true);

            this.dbContext.Hotels.Update(hotelToDelete);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
