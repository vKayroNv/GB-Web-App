using AutoMapper;
using Timesheets.Core.DTO;
using Timesheets.Storage.Models;

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
