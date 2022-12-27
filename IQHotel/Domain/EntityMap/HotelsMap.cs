using IQHotel.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace IQHotel.Domain
{
    public class HotelsMap : IEntityTypeConfiguration<Hotels>
    {
        public void Configure(EntityTypeBuilder<Hotels> builder)
        {
            builder.ToTable("Hotel_info", "dbo");

            builder.HasKey(x => x.Id);

            {

                builder.Property(x => x.Id).IsRequired();
                builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
                builder.Property(x => x.LocationTxt).HasMaxLength(500).IsRequired();
                builder.Property(x => x.LocationMap).HasMaxLength(500).IsRequired();
                builder.Property(x => x.CountryId).IsRequired();
                builder.Property(x => x.GovernorateId).IsRequired();
                builder.Property(x => x.RegionId).IsRequired();
                builder.Property(x => x.TypeId).IsRequired();
                builder.Property(x => x.Stars);//.HasDefaultValue(Key.DateTimeIQ);
                builder.Property(x => x.FloorNo).IsRequired();
                builder.Property(x => x.BuildDate).HasDefaultValue(null);
                builder.Property(x => x.Note).HasDefaultValue(null);
                builder.Property(x => x.UserInsert).IsRequired();
                builder.Property(x => x.DateInsert).HasDefaultValue(Key.DateTimeIQ);
                builder.Property(x => x.UserUpdate).HasDefaultValue(null);
                builder.Property(x => x.DateUpdate).HasDefaultValue(null);

                builder.Ignore(x => x.Phones);
                builder.Ignore(x => x.Rooms);
            }
        }
    }
}
