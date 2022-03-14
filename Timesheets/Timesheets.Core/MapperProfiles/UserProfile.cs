using AutoMapper;
using Timesheets.Entities.DTO;
using Timesheets.Entities.Models;

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
