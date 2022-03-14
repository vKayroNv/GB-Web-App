using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Entities.Models;

namespace Timesheets.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<IReadOnlyCollection<User>> Read(CancellationToken cts);
    }
}
