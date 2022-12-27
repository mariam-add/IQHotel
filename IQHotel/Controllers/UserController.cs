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
    public class UserController : MasterController
    {

        #region Readonly
        private readonly IQHotelContext _context;
        private readonly ILoggerRepository _logger;
        private readonly IUserService _service;


        #endregion

        #region const
        public UserController(IQHotelContext context, ILoggerRepository logger, IUserService service)
        {
            _context = context;
            _logger = logger;
            _service = service;
        }

        #endregion

        #region Insert
        [HttpPost]
        public async Task<IActionResult> Insert(User data)
        {
            try
            {
                ResObj res = await _service.Insert(data);

                return Response(res.Success, res.MsgCode, res.Data);
            }
            catch (Exception ex)
            {
                await _logger.WriteAsync(ex, $"User/Insert/{data.user_id}");
                return Response(false, Message.InsertFaild);
            }
        }
        #endregion
    }
}
