using IQHotel.Application;
using IQHotel.Domain;
using IQHotel.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IQHotel.Controllers
{
    [Route("API/[controller]/[action]")]
    [ApiController]
    public class HotelsController : MasterController
    {
        #region Readonly
        private readonly IQHotelContext _context;
        private readonly ILoggerRepository _logger;
        private readonly IHotelsService _service;

        
        #endregion

        #region Const
        public HotelsController(
            IQHotelContext context, 
            ILoggerRepository logger, 
            IHotelsService service)
        {
            _context = context;
            _logger = logger;
            _service = service;
        }
        #endregion

        #region allHotels
        [HttpGet]
        public async Task<IActionResult> allHotels()
        {
            try
            {
                List<Hotels> data = await _service.AllHotels();

                return Response(true, data);
            }
            catch (Exception ex)
            {
                await _logger.WriteAsync(ex, $"Hotels/GetData/");
                return Response(false, Message.GetFaild);
            }
        }
        #endregion

        #region hotelById
        [HttpGet]
        public async Task<IActionResult> HotelById(Int64 id)
        {
            try
            {
                Hotels data = await _service.HotelById(id);

                return Response(true, data);
            }
            catch (Exception ex)
            {
                await _logger.WriteAsync(ex, $"Hotels/GetData/{id}");
                return Response(false, Message.GetFaild);
            }
        }
        #endregion

        #region Insert
        [HttpPost]
        public async Task<IActionResult> Insert(Hotels data)
        {
            try
            {
                ResObj res = await _service.Insert(data);

                return Response(res.Success, res.MsgCode, res.Data);
            }
            catch (Exception ex)
            {
                await _logger.WriteAsync(ex, $"Hotel/Insert/{data.Id}");
                return Response(false, Message.InsertFaild);
            }
        }
        #endregion
        
        #region roomtypes
        [HttpGet]
        public async Task<IActionResult> Get_Rooms_type(Int64 id)
        {
            try
            {
                RoomType data = await _service.GetRoomTypes(id);

                return Response(true, data);
            }
            catch (Exception ex)
            {
                await _logger.WriteAsync(ex, $"RoomType/GetById/{id}");
                return Response(false, Message.GetFaild);
            }
        }
        #endregion
    }
}
