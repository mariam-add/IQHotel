using AutoMapper;
using IQHotel.Domain;
using IQHotel.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IQHotel.Application
{
    public class HotelsService : IHotelsService, IRegisterScopped
    {
        private readonly IQHotelContext _context;
        private readonly IDapperRepository _dapper;

        public HotelsService(IQHotelContext context, IDapperRepository dapper)
        {
            _context = context;
            _dapper = dapper;
        }

        public async Task<List<Hotels>> AllHotels()
        {
            List<Hotels> hotels = await _dapper.GetEntityListAsync<Hotels>("dbo.get_all_hotels",
                new { });

            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(long));

            List<long> ids = hotels.Select(c => c.Id).ToList();
            foreach (var id in ids) 
            {
                dt.Rows.Add(id);
            }
            

            List<Phone> phones = await _dapper.GetEntityListAsync<Phone>("dbo.get_phones", pars: new { hotel_ids = dt, });

            foreach (var hotel in hotels) 
            {
                hotel.Phones = phones.Where(c => c.Hotel_id == hotel.Id).ToList();
                //hotel.Rooms = Rooms.Where(c => c.Hotel_id == hotel.Id).ToList();
            }
            List<Room> rooms = await _dapper.GetEntityListAsync<Room>("dbo.get_rooms", pars: new { hotel_ids = dt, });

            foreach (var hotel in hotels) 
            {
                hotel.Rooms = rooms.Where(c => c.Hotel_id == hotel.Id).ToList();
                //hotel.Rooms = Rooms.Where(c => c.Hotel_id == hotel.Id).ToList();
            }

            return hotels;
        }
        
        public async Task<Hotels> HotelById(Int64 id)
        {

            Hotels hotel = await _dapper.GetEntityAsync<Hotels>("dbo.get_hotel_by_id", pars: new { hotelid = id, });
            List<Phone> phones = await _dapper.GetEntityListAsync<Phone>("dbo.get_phones_by_hotel_id", pars: new { hotelid = id, });
            List<Room> rooms = await _dapper.GetEntityListAsync<Room>("dbo.get_rooms_by_hotel_id", pars: new { hotelid = id, });

            hotel.Phones = phones;
            hotel.Rooms = rooms;

            return hotel;
        }
        
        public async Task<ResObj> Insert(Hotels hotel)
        {
            ResObj res = CheckInfo(hotel);

            if (res is not null) return res;

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                long hotel_id = await _dapper.GetEntityAsync<long>("get_last_hotel_id", pars: new { });
                hotel_id += 1;

                hotel.Id = hotel_id;

                hotel.Phones.ForEach(x => x.Hotel_id = hotel_id);
                hotel.Rooms.ForEach(x => x.Hotel_id = hotel_id);

                await _context.Hotels.AddAsync(hotel);

                if(hotel.Phones!= null)
                {
                    await _context.Phones.AddRangeAsync(hotel.Phones);
                }

                if (hotel.Rooms != null)
                {
                    await _context.Rooms.AddRangeAsync(hotel.Rooms);
                }

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return new() { Success = true, MsgCode = Message.InvalidEmail, Data = new { hotel.Id } };
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
            
        }
        
        private static ResObj CheckInfo(Hotels hotel)
        {
            if (hotel.Name.IsEmpty())
                return new() { Success = false, MsgCode = "" };

            return null;
        }
        
        public async Task<RoomType> GetRoomTypes(Int64 roomId)
        {
            RoomType roomType = await _dapper.GetEntityAsync<RoomType>("dbo.get_Rooms_types", pars: new { room_type_id = roomId });
            return roomType;
        }

    }
}
