using AutoMapper;
using Timesheets.API.Models;
using Timesheets.Core.DTO;

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
