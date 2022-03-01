using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Core.DTO;

namespace Timesheets.Core.Interfaces
{
    public interface IDataUserService : IDataService<UserDTO>
    {
        public Task<IReadOnlyCollection<UserDTO>> Read(CancellationToken cts);
    }
}
