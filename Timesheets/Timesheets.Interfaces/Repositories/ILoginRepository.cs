using System.Threading;
using System.Threading.Tasks;
using Timesheets.Entities.Models;

namespace Timesheets.Interfaces.Repositories
{
    public interface ILoginRepository : IRepository<Login>
    {
        public Task<Login> Read(string username, CancellationToken cts);
    }
}
