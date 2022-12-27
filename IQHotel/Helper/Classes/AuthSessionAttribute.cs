using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace IQHotel.Helper
{
    public class AuthSessionAttribute : TypeFilterAttribute
    {
        public AuthSessionAttribute() : base(typeof(AuthSessionImpl))
        {

        }

        private class AuthSessionImpl : IAsyncActionFilter
        {
            //private readonly IMemoryCache _cache;

            public AuthSessionImpl(/*IMemoryCache memoryCache*/)
            {
                //_cache = memoryCache;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                // put code befor exe action 

                await next();

                // put code after exe action
            }
        }
    }
}
