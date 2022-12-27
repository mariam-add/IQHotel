using IQHotel.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQHotel.Domain
{
    public class RoomsTypeMap : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            builder.ToTable("Rooms_Type", "dbo");

            builder.HasKey(x => x.id);

            {

                builder.Property(x => x.id).IsRequired();
                builder.Property(x => x.hotel_id).IsRequired();
                builder.Property(x => x.type_design).IsRequired();
                builder.Property(x => x.luxury_class).IsRequired();
                builder.Property(x => x.type_name).IsRequired();
                builder.Property(x => x.Height).IsRequired();
                builder.Property(x => x.Width).IsRequired();
                builder.Property(x => x.no_beds).IsRequired();
                builder.Property(x => x.default_Price).IsRequired().HasDefaultValue(0);
            }
        }
    }
}
