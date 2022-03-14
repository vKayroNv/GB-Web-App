using System;
using System.Threading;
using System.Threading.Tasks;

namespace Timesheets.Interfaces.Services
{
    public interface IDataService<TRequest, TResponse>
    {
        public Task<bool> Create(TRequest entity, CancellationToken cts);

        public Task<TResponse> Read(Guid id, CancellationToken cts);

        public Task<bool> Update(Guid id, TRequest entity, CancellationToken cts);

        public Task<bool> Delete(Guid id, CancellationToken cts);
    }
}
