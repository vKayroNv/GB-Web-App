using System.Threading;
using System.Threading.Tasks;

namespace Timesheets.Interfaces.Services
{
    public interface IUserService
    {
        public Task<bool> CreateProfile(string username, string password, CancellationToken cts);
        public Task<bool> DeleteProfile(string username, string password, CancellationToken cts);
        public Task<string> Authenticate(string username, string password, CancellationToken cts);
        public Task<string> RefreshToken(string token, CancellationToken cts);
    }
}
