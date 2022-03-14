using AutoMapper;
using Timesheets.Entities.DTO;
using Timesheets.Entities.Models;

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
