using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheers.Entities.Requests;
using Timesheers.Entities.Responses;

namespace Timesheets.Interfaces.Services
{
    public interface IDataEmployeeService : IDataService<EmployeeRequest, EmployeeResponse>
    {
        public Task<IReadOnlyCollection<EmployeeResponse>> Read(CancellationToken cts);
    }
}
