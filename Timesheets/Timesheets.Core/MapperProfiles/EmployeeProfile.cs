using AutoMapper;
using Timesheets.Core.DTO;
using Timesheets.Storage.Models;

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
