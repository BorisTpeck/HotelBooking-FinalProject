namespace HotelBookingSystem.Core.Implementation
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using HotelBookingSystem.Core.Common;
    using HotelBookingSystem.Core.Contracts;
    using HotelBookingSystem.Core.Models.Hotel.ViewModels;
    using HotelBookingSystem.Core.Models.Room.BindingModels;
    using HotelBookingSystem.Infrastructure.Data;
    using HotelBookingSystem.Infrastructure.Data.Models;

    using Microsoft.EntityFrameworkCore;

    public class RoomService : BaseService, IRoomService
    {
        private readonly IHotelService hotelService;

        public RoomService(HotelBookingDbContext dbContext, IMapper mapper, IHotelService hotelService) 
            : base(dbContext, mapper)
        {
            this.hotelService = hotelService;
        }
        public async Task<RoomFormBindingModel> GetByIdForEdit(int id)
        {
            RoomFormBindingModel roomForUpdate = await this.dbContext.Rooms
                .Where(r => r.Id == id)
                .ProjectTo<RoomFormBindingModel>(this.mapper.ConfigurationProvider)
                .FirstOrDefaultAsync()
                ?? throw new InvalidOperationException("Room not found.");

            roomForUpdate.Hotels = await this.hotelService.GetAll<HotelOptionViewModel>();

            return roomForUpdate;
        }

        public async Task Create(RoomFormBindingModel room)
        {
            Room roomToCreate = new Room()
            {
                Capacity = room.Capacity,
                PricePerDay = room.PricePerDay,
                Number = room.Number,
                HotelId = room.HotelId,
            };

            this.dbContext.Rooms.Add(roomToCreate);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task Edit(int id, RoomFormBindingModel room)
        {
            Room roomToEdit = await this.dbContext.Rooms
                .FirstOrDefaultAsync(r => r.Id == id)
                ?? throw new InvalidOperationException("Room not found.");

            roomToEdit.Capacity = room.Capacity;
            roomToEdit.PricePerDay = room.PricePerDay;
            roomToEdit.HotelId = room.HotelId;
            roomToEdit.Number = room.Number;
            roomToEdit.HotelId = room.HotelId;

            this.dbContext.Rooms.Update(roomToEdit);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Room roomToDelete = await this.dbContext.Rooms
                .FirstOrDefaultAsync(r => r.Id == id)
                ?? throw new InvalidOperationException("Room not found.");

            roomToDelete.IsDeleted = true;

            this.dbContext.Rooms.Update(roomToDelete);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
