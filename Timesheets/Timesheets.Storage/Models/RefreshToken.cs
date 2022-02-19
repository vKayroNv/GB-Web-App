using System;
using System.Collections.Generic;
using System.Text;

namespace Timesheets.Storage.Models
{
    public sealed class RefreshToken : Entity
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public Guid LoginId { get; set; }

        public bool IsExpired => DateTime.UtcNow >= Expires;
    }
}
