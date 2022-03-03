using AutoMapper;
using Timesheets.Entities.DTO;
using Timesheets.Entities.VievModels;

namespace Timesheets.API.MapperProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDTO, EmployeeModel>().ReverseMap();
        }
    }
}
