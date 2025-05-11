namespace HotelBookingSystem.Core.Implementation
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using HotelBookingSystem.Core.Common;
    using HotelBookingSystem.Core.Contracts;
    using HotelBookingSystem.Core.Models.Facility.ViewModels;
    using HotelBookingSystem.Infrastructure.Data;

    using Microsoft.EntityFrameworkCore;

    public class FacilityService : BaseService, IFacilityService
    {
        public FacilityService(HotelBookingDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<FacilityViewModel>> GetAll()
        {
            IEnumerable<FacilityViewModel> facilities = await this.dbContext.Facilities
                .ProjectTo<FacilityViewModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();

            return facilities;
        }
    }
}
