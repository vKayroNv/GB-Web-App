using System;

namespace Timesheets.Core.DTO
{
    public sealed class LoginDTO : EntityDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid RefreshTokenId { get; set; }
    }
}
