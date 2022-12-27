using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IQHotel.Domain
{
    public class BookingMap : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings", "dbo");

            builder.HasKey(x => x.id);
            {
                builder.Property(x => x.id).IsRequired();
                builder.Property(x => x.hotel_id).IsRequired();
                builder.Property(x => x.customer_id).IsRequired();
                builder.Property(x => x.floor_id).IsRequired();
                builder.Property(x => x.room_id).IsRequired();
                builder.Property(x => x.start_booking).HasDefaultValue(null);
                builder.Property(x => x.end_booking).IsRequired();
                builder.Property(x => x.arrrival).HasDefaultValue(null);
                builder.Property(x => x.checkout).HasDefaultValue(null);
                builder.Property(x => x.date_insert).IsRequired();
                builder.Property(x => x.user_id).IsRequired();
                builder.Property(x => x.isCanceled).HasDefaultValue(false) ;
            }
        }

    }
}
