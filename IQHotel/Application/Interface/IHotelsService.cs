using IQHotel.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IQHotel.Application
{
    public interface IHotelsService
    {
        public Task<List<Hotels>> AllHotels();
        public Task<Hotels> HotelById(Int64 id);
        public Task<ResObj> Insert(Hotels hotel);
        public Task<RoomType> GetRoomTypes(Int64 id);
    }
}
