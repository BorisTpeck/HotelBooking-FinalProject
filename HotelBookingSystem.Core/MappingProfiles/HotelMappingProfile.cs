namespace HotelBookingSystem.Core.MappingProfiles
{
    using HotelBookingSystem.Core.Common;
    using HotelBookingSystem.Core.Models.Hotel.BindingModels;
    using HotelBookingSystem.Core.Models.Hotel.ViewModels;
    using HotelBookingSystem.Infrastructure.Data.Models;

    public class HotelMappingProfile : MappingProfile
    {
        public HotelMappingProfile()
        {
            this.CreateMap<Hotel, HotelListItemViewModel>()
                .ForMember(dest => dest.Location,
                    opt => opt.MapFrom(src => src.Location.Name))
                .ForMember(dest => dest.Facilities,
                    opt => opt.MapFrom(src => src.Facilities.Select(hf => hf.Facility.Type)))
                .ForMember(dest => dest.HasActiveReservations,
                    opt => opt.MapFrom(src => src.Reservations.Any(x => x.ToDate > DateTime.Today)));

            this.CreateMap<Hotel, HotelFormBindingModel>()
                .ForMember(dest => dest.SelectedFacilityIds,
                    opt => opt.MapFrom(src => src.Facilities.Select(hf => hf.FacilityId)))
                .ForMember(dest => dest.SelectedLocationId,
                    opt => opt.MapFrom(src => src.LocationId))
                .ForMember(dest => dest.Facilities,
                    opt => opt.Ignore());

            this.CreateMap<Hotel, HotelOptionViewModel>();

            this.CreateMap<Hotel, ListHotelsRoomsViewModel>()
                .ForMember(dest => dest.HotelId,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.HotelName,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Rooms,
                    opt => opt.MapFrom(src => src.Rooms));

            this.CreateMap<Hotel, HotelDetailsViewModel>()
                .ForMember(dest => dest.Location,
                    opt => opt.MapFrom(src => src.Location.Name))
                .ForMember(dest => dest.Facilities,
                    opt => opt.MapFrom(src => src.Facilities.Select(hf => hf.Facility.Type)));
        }
    }
}
