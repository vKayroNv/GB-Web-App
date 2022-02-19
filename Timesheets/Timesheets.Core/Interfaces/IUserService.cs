using System.Threading;
using System.Threading.Tasks;
using Timesheets.Core.Responses;

namespace Timesheets.Core.Interfaces
{
    public interface IUserService
    {
        public Task<bool> CreateProfile(string username, string password, CancellationToken cts);
        public Task<bool> DeleteProfile(string username, string password, CancellationToken cts);
        public Task<TokenResponse> Authenticate(string username, string password, CancellationToken cts);
        public Task<string> RefreshToken(string token, CancellationToken cts);
    }
}
