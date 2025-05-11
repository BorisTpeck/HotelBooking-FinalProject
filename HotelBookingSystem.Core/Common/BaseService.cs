namespace HotelBookingSystem.Core.Common
{
    using AutoMapper;

    using HotelBookingSystem.Infrastructure.Data;

    public abstract class BaseService
    {
        protected readonly HotelBookingDbContext dbContext;
        protected readonly IMapper mapper;

        protected BaseService(HotelBookingDbContext dbContext, IMapper mapper) 
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
    }
}
