using IQHotel.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IQHotel.Domain
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers", "dbo");

            builder.HasKey(x => x.Id);

            {

                builder.Property(x => x.Id).IsRequired();
                builder.Property(x => x.FullName).HasMaxLength(150).IsRequired();
                builder.Property(x => x.Phone).HasMaxLength(20).IsRequired();
                builder.Property(x => x.NoNationalCardLink).HasMaxLength(200).IsRequired();
                builder.Property(x => x.NoPassport).HasMaxLength(200).IsRequired();
                builder.Property(x => x.PhotoCustomer).HasMaxLength(300).IsRequired();
                builder.Property(x => x.PhotoCard).HasMaxLength(300).IsRequired();
                builder.Property(x => x.IsActive).IsRequired();
                builder.Property(x => x.InsertDate).HasDefaultValue(Key.DateTimeIQ);
                builder.Property(x => x.UpdateDate).HasDefaultValue(null);
                builder.Property(x => x.IsDeleted).HasDefaultValue(false).IsRequired();
                builder.Property(x => x.DeleteDate).HasDefaultValue(null);
                builder.Property(x => x.Version).IsRowVersion();
            }
        }
    }
}
