using AutoMapper;
using Timesheets.API.Models;
using Timesheets.Core.DTO;

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
