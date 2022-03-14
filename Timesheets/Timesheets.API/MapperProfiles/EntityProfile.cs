using AutoMapper;
using Timesheets.API.Models;
using Timesheets.Core.DTO;
using Timesheets.Storage.Models;

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
