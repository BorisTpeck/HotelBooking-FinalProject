namespace HotelBookingSystem.Core.Models.Room.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    using HotelBookingSystem.Core.Models.Hotel.ViewModels;
    using HotelBookingSystem.Infrastructure.Common;
    using HotelBookingSystem.Infrastructure.Common.Enums;

    public class RoomFormBindingModel
    {
        public RoomCapacityType Capacity { get; set; }

        [Range(typeof(decimal), DataConstants.RoomMinPricePerDay, DataConstants.RoomMaxPricePerDay)]
        public decimal PricePerDay { get; set; }

        [Range(DataConstants.RoomNumberMinValue, int.MaxValue)]
        public int Number { get; set; }

        public int HotelId { get; set; }

        public IEnumerable<HotelOptionViewModel> Hotels { get; set; } = new List<HotelOptionViewModel>();
    }
}
