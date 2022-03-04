using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheers.Entities.Requests;
using Timesheers.Entities.Responses;

namespace Timesheets.Interfaces.Services
{
    public interface IDataUserService : IDataService<UserRequest, UserResponse>
    {
        public Task<IReadOnlyCollection<UserResponse>> Read(CancellationToken cts);
    }
}
