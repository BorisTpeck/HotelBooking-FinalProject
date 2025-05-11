namespace HotelBookingSystem.Infrastructure.Data.Configurations
{
    using HotelBookingSystem.Infrastructure.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class HotelEntityTypeConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder
                .HasOne(h => h.Location)
                .WithMany(l => l.Hotels)
                .HasForeignKey(h => h.LocationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
