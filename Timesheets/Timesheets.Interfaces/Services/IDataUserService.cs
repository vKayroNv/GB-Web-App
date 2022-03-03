using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Entities.DTO;

namespace Timesheets.Interfaces.Services
{
    public interface IDataUserService : IDataService<UserDTO>
    {
        public Task<IReadOnlyCollection<UserDTO>> Read(CancellationToken cts);
    }
}
