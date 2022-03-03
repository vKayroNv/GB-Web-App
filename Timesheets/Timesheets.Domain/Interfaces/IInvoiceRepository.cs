using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Domain.Models;

namespace Timesheets.Domain.Interfaces
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        public Task<IReadOnlyCollection<Invoice>> Read(CancellationToken cts);
    }
}
