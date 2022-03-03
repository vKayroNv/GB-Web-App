using AutoMapper;
using Timesheets.Entities.DTO;
using Timesheets.Entities.VievModels;

namespace Timesheets.API.MapperProfiles
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<EntityDTO, EntityModel>().ReverseMap();
        }
    }
}
