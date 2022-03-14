using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Entities.Models;

namespace Timesheets.Interfaces.Repositories
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        public Task<IReadOnlyCollection<Invoice>> Read(CancellationToken cts);
    }
}
