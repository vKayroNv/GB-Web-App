using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheets.Storage.Models
{
    [Table("logins")]
    public class Login : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid RefreshTokenId { get; set; }
    }
}
