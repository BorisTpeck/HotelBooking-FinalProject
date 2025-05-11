namespace HotelBookingSystem.Core.MappingProfiles
{
    using HotelBookingSystem.Core.Common;
    using HotelBookingSystem.Core.Models.Room.BindingModels;
    using HotelBookingSystem.Core.Models.Room.ViewModels;
    using HotelBookingSystem.Infrastructure.Data.Models;

    internal class RoomMappingProfile : MappingProfile
    {
        public RoomMappingProfile()
        {
            this.CreateMap<Room, RoomListItemViewModel>()
                .ForMember(dest => dest.HasCurrentOrFutureReservations,
                    opt => opt.MapFrom(src => src.Reservations
                    .Any(x => x.ToDate > DateTime.Today)));

            this.CreateMap<Room, RoomReservationListItemViewModel>();

            this.CreateMap<Room, RoomFormBindingModel>();
        }
    }
}
