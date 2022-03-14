using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Entities.Models;

namespace Timesheets.Interfaces.Managers
{
    public interface IInvoiceManager
    {
        public Task<bool> Create(DateTime dateStart, DateTime dateEnd, CancellationToken cts);

        public Task<Invoice> Read(Guid id, CancellationToken cts);

        public Task<IReadOnlyCollection<Invoice>> Read(CancellationToken cts);

        public Task<bool> IncludeSheets(Guid invoiceId, IEnumerable<Sheet> sheets, CancellationToken cts);
    }
}
