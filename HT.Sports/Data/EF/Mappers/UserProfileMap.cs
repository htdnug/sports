using HT.Sports.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HT.Sports.Data.EF.Mappers
{
    internal class UserProfileMap : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("dbo", "UserProfile").HasKey(x => x.Id);
            builder.Property(x => x.DisplayName).HasMaxLength(100).IsRequired();
        }
    }
}
