using IQHotel.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IQHotel.Domain
{
    public class PhonesMap : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.ToTable("phones", "dbo");

            builder.HasKey(x => x.Id);

            {

                builder.Property(x => x.Id).IsRequired();
                builder.Property(x => x.PhoneNum).HasMaxLength(191).IsRequired();
                builder.Property(x => x.Phone_verified_at);
                builder.Property(x => x.Hotel_id).IsRequired();
                builder.Property(x => x.Created_at).HasDefaultValue(Key.DateTimeIQ);
                builder.Property(x => x.Updated_at);
            }
        }
    }
}
