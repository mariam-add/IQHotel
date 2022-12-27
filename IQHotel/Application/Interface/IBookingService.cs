
using IQHotel.Domain;
using System;
using System.Threading.Tasks;

namespace IQHotel.Application
{
    public interface IBookingService
    {
        public Task<ResObj> Insert(Booking booking);
        public Task<ResObj> Cancel(int id);
        public Task<ResObj> accept(int id, DateTime startDate);
    }
}
