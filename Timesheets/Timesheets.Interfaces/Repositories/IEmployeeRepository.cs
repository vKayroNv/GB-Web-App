using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Entities.Models;

namespace Timesheets.Interfaces.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        public Task<IReadOnlyCollection<Employee>> Read(CancellationToken cts);
    }
}
