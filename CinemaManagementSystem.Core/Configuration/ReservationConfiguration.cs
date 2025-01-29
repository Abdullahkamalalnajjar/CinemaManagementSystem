using CinemaManagementSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagementSystem.Core.Configuration
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(builder => builder.TotalPrice).HasColumnType("decimal(18,2)");
        }
    }
}
