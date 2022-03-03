using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Entities.DTO;

namespace Timesheets.Interfaces.Services
{
    public interface IDataEmployeeService : IDataService<EmployeeDTO>
    {
        public Task<IReadOnlyCollection<EmployeeDTO>> Read(CancellationToken cts);
    }
}
