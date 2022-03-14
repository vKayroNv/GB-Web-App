using System.Threading;
using System.Threading.Tasks;
using Timesheets.Storage.Models;

namespace Timesheets.Storage.Interfaces
{
    public interface ILoginRepository : IRepository<Login>
    {
        public Task<Login> Read(string username, CancellationToken cts);
    }
}
