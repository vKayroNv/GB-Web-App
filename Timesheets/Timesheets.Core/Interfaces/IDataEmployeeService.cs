using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Storage.Models;

namespace Timesheets.Core.Interfaces
{
    public interface IDataEmployeeService : IDataService<Employee>
    {
        public Task<IReadOnlyCollection<Employee>> Read(CancellationToken cts);
    }
}
