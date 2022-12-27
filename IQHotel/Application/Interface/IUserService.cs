using IQHotel.Domain;
using System.Threading.Tasks;

namespace IQHotel.Application
{
    public interface IUserService
    {
        public Task<ResObj> Insert(User user);
    }
}
