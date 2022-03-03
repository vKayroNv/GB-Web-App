using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Entities.Models;

namespace Timesheets.Interfaces.Managers
{
    public interface IManagerBase<T>
    {
        Task<bool> Create(DateTime dateTime, CancellationToken cts);
        Task<IReadOnlyCollection<T>> Read(CancellationToken cts);
        Task<Sheet> Read(Guid id, CancellationToken cts);
    }
}