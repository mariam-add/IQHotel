
using IQHotel.Domain;
using IQHotel.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace IQHotel.Application
{
    public class BookingService : IBookingService, IRegisterScopped
    {
        private readonly IQHotelContext _context;
        private readonly IDapperRepository _dapper;

        public BookingService(IQHotelContext context, IDapperRepository dapper)
        {
            _context = context;
            _dapper = dapper;
        }

        private static ResObj CheckInfo(Booking booking)
        {
            //check validation
            
            //if (booking.)
            //    return new() { Success = false, MsgCode = "" };

            return null;
        }
        public async Task<ResObj> Insert(Booking booking)
        {
            ResObj res = CheckInfo(booking);

            if (res is not null) return res;

            await _context.Bookings.AddAsync(booking);

            await _context.SaveChangesAsync();

            return new() { Success = true, MsgCode = Message.InvalidEmail, Data = new { booking.id } };
        }
        public async Task<ResObj> Cancel(int id)
        {
            Booking booking = await _context.Bookings.FindAsync(id);

            booking.isCanceled = true;

            //await _context.Bookings.AddAsync(booking);

            await _context.SaveChangesAsync();

            return new() { Success = true, MsgCode = Message.InvalidEmail, Data = new { booking.id } };
        }

        public async Task<ResObj> accept(int id,DateTime startDate)
        {
            Booking booking = await _context.Bookings.FindAsync(id);

            booking.start_booking = startDate;

            await _context.SaveChangesAsync();

            return new() { Success = true, MsgCode = Message.InvalidEmail, Data = new { booking.id } };
        }
    }
}
