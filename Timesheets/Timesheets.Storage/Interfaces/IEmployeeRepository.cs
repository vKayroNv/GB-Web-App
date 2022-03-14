using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Storage.Models;

namespace Timesheets.Storage.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        public Task<IReadOnlyCollection<Employee>> Read(CancellationToken cts);
    }
}
