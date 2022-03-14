using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Entities.Models;

namespace Timesheets.Interfaces.Managers
{
    public interface ISheetManager
    {
        public Task<bool> Create(DateTime dateTime, CancellationToken cts);

        public Task<Sheet> Read(Guid id, CancellationToken cts);

        public Task<IReadOnlyCollection<Sheet>> Read(CancellationToken cts);

        public Task<bool> Approve(Guid sheetId, CancellationToken cts);
    }
}
