using AutoMapper;
using Timesheets.Core.DTO;
using Timesheets.Storage.Models;

namespace Timesheets.Core.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
