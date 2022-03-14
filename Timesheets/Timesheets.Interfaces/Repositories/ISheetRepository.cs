using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Entities.Models;

namespace Timesheets.Interfaces.Repositories
{
    public interface ISheetRepository : IRepository<Sheet>
    {
        public Task<IReadOnlyCollection<Sheet>> Read(CancellationToken cts);
    }
}
