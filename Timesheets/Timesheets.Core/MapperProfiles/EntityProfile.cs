using AutoMapper;
using Timesheets.Core.DTO;
using Timesheets.Storage.Models;

namespace Timesheets.Core.MapperProfiles
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<Entity, EntityDTO>().ReverseMap();
        }
    }
}
