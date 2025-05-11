namespace HotelBookingSystem.Infrastructure.Common
{
    public class DataConstants
    {
        public const int LocationNameMaxLength = 128;

        public const int HotelNameMaxLength = 64;
        public const int HotelAddressMaxLength = 256;
        public const int HotelImageUrlMaxLength = 2048;

        public const int ClientFirstNameMaxLength = 64;
        public const int ClientFirstNameMinLength = 2;

        public const int ClientLastNameMaxLength = 64;
        public const int ClientLastNameMinLength = 2;

        public const int ClientPhoneNumberMaxLength = 15;

        public const string RoomMinPricePerDay = "10";
        public const string RoomMaxPricePerDay = "10000";
        public const int RoomNumberMinValue = 1;
    }
}
