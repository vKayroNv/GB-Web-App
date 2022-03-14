using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Storage.Models;

namespace Timesheets.Storage.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<IReadOnlyCollection<User>> Read(CancellationToken cts);
    }
}
