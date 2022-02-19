using Timesheets.Storage.Models;

namespace Timesheets.Core.Responses
{
    public sealed class AuthResponse
    {
        public string Password { get; set; }

        public RefreshToken LatestRefreshToken { get; set; }
    }
}
