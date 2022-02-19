using System;
using System.Collections.Generic;
using System.Text;

namespace Timesheets.Core.Responses
{
    public sealed class TokenResponse
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }

}
