using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timesheets.Core.Interfaces
{
    public interface IDataService<T>
    {
        public Task<bool> Create(T entity, CancellationToken cts);

        public Task<T> Read(Guid id, CancellationToken cts);

        public Task<bool> Update(T entity, CancellationToken cts);

        public Task<bool> Delete(Guid id, CancellationToken cts);
    }
}
