using System.Threading;
using System.Threading.Tasks;
using Timesheets.Core.Responses;

namespace Timesheets.Core.Interfaces
{
    public interface IUserService
    {
        public TokenResponse Authenticate(string user, string password);

        public string RefreshToken(string token);
    }
}
