using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Entities.Models;

namespace Timesheets.Interfaces.Managers
{
    public interface ISheetManager : IManagerBase<Sheet>
    {
        public Task<bool> Approve(Guid sheetId, CancellationToken cts);
    }
}
