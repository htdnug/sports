using HT.Sports.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HT.Sports.Data.EF.Mappers
{
    internal class TripMap : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.ToTable("dbo", "Trip").HasKey(x => x.Id);
            builder.Property(x => x.DateOccurred).IsRequired().HasColumnType("date");

            builder
                .HasOne(t => t.UserProfile)
                .WithMany(up => up.Trips)
                .HasForeignKey(t => t.UserProfileId);
        }
    }
}
