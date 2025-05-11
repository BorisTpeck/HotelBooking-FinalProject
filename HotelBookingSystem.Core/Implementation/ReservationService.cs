namespace HotelBookingSystem.Core.Implementation
{
    using System.Linq;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using HotelBookingSystem.Core.Common;
    using HotelBookingSystem.Core.Contracts;
    using HotelBookingSystem.Core.Models.Reservation.BindingModels;
    using HotelBookingSystem.Core.Models.Reservation.ViewModels;
    using HotelBookingSystem.Core.Models.Room.ViewModels;
    using HotelBookingSystem.Infrastructure.Data;
    using HotelBookingSystem.Infrastructure.Data.Models;

    using Microsoft.EntityFrameworkCore;

    public class ReservationService : BaseService, IReservationService
    {
        public ReservationService(HotelBookingDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }

        public async Task<IEnumerable<RoomReservationListItemViewModel>> GetAvailableRooms(int hotelId, DateTime fromDate, DateTime toDate)
        {
            IEnumerable<int> bookedRoomIds = await this.dbContext.Reservations
                .Where(x => x.HotelId == hotelId &&
                            x.FromDate < toDate && x.ToDate > fromDate)
                .Select(x => x.RoomId)
                .ToListAsync();

            IEnumerable<RoomReservationListItemViewModel> availableRooms = await this.dbContext.Rooms
                .Where(x => x.HotelId == hotelId && !bookedRoomIds.Contains(x.Id))
                .ProjectTo<RoomReservationListItemViewModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();

            int totalDays = (toDate - fromDate).Days;
            foreach (var availableRoom in availableRooms)
            {
                availableRoom.TotalPrice = availableRoom.PricePerDay * totalDays;
            }

            return availableRooms;
        }

        public async Task<IEnumerable<MineReservationViewModel>> GetMine(int clientId)
        {
            IEnumerable<MineReservationViewModel> reservations = await this.dbContext.Reservations
                .IgnoreQueryFilters()
                .Where(x => x.ClientId == clientId)
                .OrderByDescending(x => x.CreatedOn)
                .ProjectTo<MineReservationViewModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();

            return reservations;
        }

        public async Task Create(int clientId, CreateReservationBindingModel reservationData)
        {
            bool isHotelExists = await this.dbContext.Hotels.AnyAsync(x => x.Id == reservationData.HotelId);

            if (!await this.dbContext.Hotels.AnyAsync(x => x.Id == reservationData.HotelId))
            {
                throw new InvalidOperationException("The selected hotel does not exist.");
            }

            bool isRoomExist = this.dbContext.Rooms.Any(x => x.Id == reservationData.RoomId);

            if (!isRoomExist)
            {
                throw new InvalidOperationException("The selected room does not exist in the chosen hotel.");
            }
            
            bool hasAlreadyReservation = await this.dbContext.Reservations
                .AnyAsync(x => x.HotelId == reservationData.HotelId && x.RoomId == reservationData.RoomId &&
                               x.FromDate < reservationData.ToDate && x.ToDate > reservationData.FromDate);

            if (hasAlreadyReservation)
            {
                throw new InvalidOperationException("This room is already reserved during the selected period.");
            }

            decimal pricePerDay = await this.dbContext.Rooms
                .Where(x => x.Id == reservationData.RoomId)
                .Select(x => x.PricePerDay)
                .FirstOrDefaultAsync();

            decimal totalPrice = pricePerDay * (reservationData.ToDate - reservationData.FromDate).Days;

            Reservation reservation = new Reservation
            {
                ClientId = clientId,
                HotelId = reservationData.HotelId,
                RoomId = reservationData.RoomId,
                TotalPrice = totalPrice,
                FromDate = reservationData.FromDate,
                ToDate = reservationData.ToDate,
                CreatedOn = DateTime.UtcNow,
            };

            this.dbContext.Reservations.Add(reservation);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
