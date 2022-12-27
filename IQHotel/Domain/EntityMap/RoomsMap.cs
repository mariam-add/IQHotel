using IQHotel.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQHotel.Domain
{
    public class RoomsMap : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms", "dbo");

            builder.HasKey(x => x.Id);

            {

                builder.Property(x => x.Id).IsRequired();
                builder.Property(x => x.Hotel_id).IsRequired();
                builder.Property(x => x.Room_number).IsRequired();
                builder.Property(x => x.Room_type_id).IsRequired();
                builder.Property(x => x.Floor).HasDefaultValue(1);
                builder.Property(x => x.Price).HasDefaultValue(0);
            }
        }
    }
}
