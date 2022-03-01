using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Core.DTO;

namespace Timesheets.Core.Interfaces
{
    public interface IDataEmployeeService : IDataService<EmployeeDTO>
    {
        public Task<IReadOnlyCollection<EmployeeDTO>> Read(CancellationToken cts);
    }
}
