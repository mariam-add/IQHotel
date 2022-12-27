using AutoMapper;
using IQHotel.Domain;
using IQHotel.Helper;
using System.Threading.Tasks;

namespace IQHotel.Application
{
    public class UserService : IUserService, IRegisterScopped
    {
        private readonly IQHotelContext _context;
        private readonly IDapperRepository _dapper;
        private readonly IMapper _mapper;

        public UserService(IQHotelContext context, IDapperRepository dapper, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _dapper = dapper;
        }

        private static ResObj CheckInfo(User user)
        {
            //check validation

            if (user.Name.IsEmpty())
                return new() { Success = false, MsgCode = "" };

            return null;
        }

        public async Task<ResObj> Insert(User user)
        {
            ResObj res = CheckInfo(user);

            if (res is not null) return res;

            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            UserManager userManager = _mapper.Map<User, UserManager>(user);

            string token = JsonWebToken.GenerateToken(userManager);

            return new() { Success = true, MsgCode = Message.InvalidEmail, Data = new { token } };

        }
    }
}
