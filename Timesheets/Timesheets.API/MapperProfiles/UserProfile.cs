using AutoMapper;
using Timesheets.Entities.DTO;
using Timesheets.Entities.VievModels;

namespace Timesheets.API.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, UserModel>().ReverseMap();
        }
    }
}
