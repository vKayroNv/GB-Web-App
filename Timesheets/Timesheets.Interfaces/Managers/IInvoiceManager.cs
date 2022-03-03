using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Entities.Models;

namespace Timesheets.Interfaces.Managers
{
    public interface IInvoiceManager : IManagerBase<Invoice>
    {
        public Task<bool> IncludeSheets(Guid invoiceId, IEnumerable<Sheet> sheets, CancellationToken cts);
    }
}
