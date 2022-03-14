using System;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Entities.Models;

namespace Timesheets.Interfaces.Repositories
{
    public interface IRefreshTokenRepository
    {
        public Task<bool> Add(RefreshToken token, CancellationToken cts);
        public Task<RefreshToken> Get(Guid id, CancellationToken cts);
        public Task<RefreshToken> Get(string token, CancellationToken cts);
        public Task<bool> Remove(Guid id, CancellationToken cts);
    }
}
