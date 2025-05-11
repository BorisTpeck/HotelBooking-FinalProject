namespace HotelBookingSystem.Infrastructure.Data.Configurations
{
    using HotelBookingSystem.Infrastructure.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class HotelFacilityTypeConfiguration : IEntityTypeConfiguration<HotelFacility>
    {
        public void Configure(EntityTypeBuilder<HotelFacility> builder)
        {
            builder.HasKey(hf => new { hf.HotelId, hf.FacilityId });

            builder
                .HasOne(hf => hf.Hotel)
                .WithMany(h => h.Facilities)
                .HasForeignKey(hf => hf.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(hf => hf.Facility)
                .WithMany(f => f.Hotels)
                .HasForeignKey(hf => hf.FacilityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
