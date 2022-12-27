using IQHotel.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;


namespace IQHotel.Domain
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "dbo");

            builder.HasKey(x => x.user_id);

            {

                builder.Property(x => x.user_id).IsRequired();
                builder.Property(x => x.PhoneNum).IsRequired();
                builder.Property(x => x.Password).IsRequired();
                builder.Property(x => x.Name).IsRequired();
                builder.Property(x => x.Role_id).HasDefaultValue(1);
                builder.Property(x => x.Profile_id).HasDefaultValue(null);
            }
        }
    }
}
