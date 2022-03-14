using System;

namespace Timesheets.Entities.DTO
{
    public sealed class RefreshTokenDTO : EntityDTO
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public Guid LoginId { get; set; }

        public bool IsExpired => DateTime.UtcNow >= Expires;
    }
}
