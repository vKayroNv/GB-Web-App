using AutoMapper;
using Timesheets.Entities.DTO;
using Timesheets.Entities.Models;

namespace Timesheets.Core.MapperProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
