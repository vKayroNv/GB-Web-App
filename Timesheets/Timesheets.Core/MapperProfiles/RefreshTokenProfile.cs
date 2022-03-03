using AutoMapper;
using Timesheets.Entities.DTO;
using Timesheets.Entities.Models;

namespace Timesheets.Core.MapperProfiles
{
    public class RefreshTokenProfile : Profile
    {
        public RefreshTokenProfile()
        {
            CreateMap<RefreshToken, RefreshTokenDTO>().ReverseMap();
        }
    }
}
