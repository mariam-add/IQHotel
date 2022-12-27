using Microsoft.EntityFrameworkCore;

namespace IQHotel.Domain
{
    public class IQHotelContext : DbContext
    {
        public IQHotelContext(DbContextOptions<IQHotelContext> options) : base(options)
        {

        }

        protected IQHotelContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new HotelsMap());
            modelBuilder.ApplyConfiguration(new PhonesMap());
            modelBuilder.ApplyConfiguration(new RoomsMap());
            modelBuilder.ApplyConfiguration(new RoomsTypeMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new BookingMap());
        }

        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}