namespace HotelBookingSystem.Core.Implementation
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using HotelBookingSystem.Core.Common;
    using HotelBookingSystem.Core.Contracts;
    using HotelBookingSystem.Core.Models.Location.ViewModels;
    using HotelBookingSystem.Infrastructure.Data;

    using Microsoft.EntityFrameworkCore;

    public class LocationService : BaseService, ILocationService
    {
        public LocationService(HotelBookingDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<LocationViewModel>> GetAll()
        {
            IEnumerable<LocationViewModel> locations = await this.dbContext.Locations
                .ProjectTo<LocationViewModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();

            return locations;
        }
    }
}
