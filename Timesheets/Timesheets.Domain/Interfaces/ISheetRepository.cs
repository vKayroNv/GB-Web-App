using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Domain.Models;

namespace Timesheets.Domain.Interfaces
{
    public interface ISheetRepository : IRepository<Sheet>
    {
        public Task<IReadOnlyCollection<Sheet>> Read(CancellationToken cts);
    }
}
