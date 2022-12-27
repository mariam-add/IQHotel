using IQHotel.Domain;
using IQHotel.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace IQHotel.Controllers
{
    [Route("API/[controller]/[action]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        //protected UserManager UserManager
        //{
            //get
            //{
            //    // reading claim "UserProfile" from JWT Token
            //    string user = HttpContext.User.Claims
            //        .Where(x => x.Type == ClaimInfo.UserManager)
            //        .FirstOrDefault().Value;

            //    // if claim is exists then deserialize it 
            //    if (!string.IsNullOrWhiteSpace(user))
            //    {
            //        return JsonConvert.DeserializeObject<UserManager>(user);
            //    }

            //    // if no claim is found return null means the user is not logged in
            //    return null;
            //}
        //}

        protected new IActionResult Response(bool success)
        {
            return Ok(new { success });
        }

        protected new IActionResult Response(bool success, object data)
        {
            return Ok(new { success, data });
        }

        protected new IActionResult Response(bool success, string msgCode)
        {
            return Ok(new { success, msg = Message.MsgDictionary["Ar"][msgCode] });
        }

        protected new IActionResult Response(bool success, string msgCode, object data)
        {
            return Ok(new { success, msg = Message.MsgDictionary["Ar"][msgCode], data });
        }
    }
}
