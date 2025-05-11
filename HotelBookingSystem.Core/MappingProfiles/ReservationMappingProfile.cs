namespace HotelBookingSystem.Core.MappingProfiles
{
    using HotelBookingSystem.Core.Common;
    using HotelBookingSystem.Core.Models.Reservation.ViewModels;
    using HotelBookingSystem.Infrastructure.Data.Models;

    public class ReservationMappingProfile : MappingProfile
    {
        public ReservationMappingProfile()
        {
            this.CreateMap<Reservation, MineReservationViewModel>()
                .ForMember(dest => dest.HotelName,
                    opt => opt.MapFrom(src => src.Hotel.Name))
                .ForMember(dest => dest.PricePerDay,
                    opt => opt.MapFrom(src => src.Room.PricePerDay))
                .ForMember(dest => dest.Location,
                    opt => opt.MapFrom(src => src.Hotel.Location.Name));
        }
    }
}
