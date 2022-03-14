using AutoMapper;
using Timesheets.Core.DTO;
using Timesheets.Storage.Models;

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
