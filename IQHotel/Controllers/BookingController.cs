using IQHotel.Application;
using IQHotel.Domain;
using IQHotel.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace IQHotel.Controllers
{
    [Route("API/[controller]/[action]")]
    [ApiController]
    public class BookingController : MasterController
    {

        #region Readonly
        private readonly IQHotelContext _context;
        private readonly ILoggerRepository _logger;
        private readonly IBookingService _service;


        #endregion

        #region const
        public BookingController(IQHotelContext context, ILoggerRepository logger, IBookingService service)
        {
            _context = context;
            _logger = logger;
            _service = service;
        }

        #endregion

        #region Insert
        [HttpPost]
        public async Task<IActionResult> Insert(Booking data)
        {
            try
            {
                ResObj res = await _service.Insert(data);

                return Response(res.Success, res.MsgCode, res.Data);
            }
            catch (Exception ex)
            {
                await _logger.WriteAsync(ex, $"Booking/Insert/{data.user_id}");
                return Response(false, Message.InsertFaild);
            }
        }

        #endregion

        #region Cancel
        [HttpPut]
        public async Task<IActionResult> Cancel(int id)
        {
            try
            {
                ResObj res = await _service.Cancel(id);

                return Response(res.Success, res.MsgCode, res.Data);
            }
            catch (Exception ex)
            {
                await _logger.WriteAsync(ex, $"Booking/Cancel/{id}");
                return Response(false, Message.UpdateFaild);
            }
        }

        #endregion

        #region Accept
        [HttpPut]
        public async Task<IActionResult> Accept(int id, DateTime startDate)
        {
            try
            {
                ResObj res = await _service.accept(id, startDate);

                return Response(res.Success, res.MsgCode, res.Data);
            }
            catch (Exception ex)
            {
                await _logger.WriteAsync(ex, $"Booking/Accept/{id}");
                return Response(false, Message.UpdateFaild);
            }
        }

        #endregion


    }
}
