namespace HotelBookingSystem.Common.Extenstions
{
    using System.ComponentModel.DataAnnotations;

    public static class EnumExtenstions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            DisplayAttribute displayAttribute = enumValue
                .GetType()
                .GetField(enumValue.ToString())
                ?.GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault() as DisplayAttribute;

            return displayAttribute?.Name ?? enumValue.ToString();
        }
    }
}
