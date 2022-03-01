using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Storage.Models;

namespace Timesheets.Core.Interfaces
{
    public interface IDataUserService : IDataService<User>
    {
        public Task<IReadOnlyCollection<User>> Read(CancellationToken cts);
    }
}
