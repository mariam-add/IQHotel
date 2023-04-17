using AutoMapper;

namespace IQHotel.Domain
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Like this => CreateMap<MainEntity, DtoEntity>();

            //CreateMap<UserProfile, UserManager>().ReverseMap();
            CreateMap<User, UserManager>().ReverseMap();
        }
    }
}
