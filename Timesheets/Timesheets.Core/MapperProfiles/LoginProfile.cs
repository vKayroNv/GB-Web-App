using AutoMapper;
using Timesheets.Entities.DTO;
using Timesheets.Entities.Models;

namespace Timesheets.Core.MapperProfiles
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<Login, LoginDTO>().ReverseMap();
        }
    }
}
