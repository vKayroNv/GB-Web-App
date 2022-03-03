using System;
using System.ComponentModel.DataAnnotations;

namespace Timesheets.Entities.Models
{
    public sealed class Login : Entity
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public Guid RefreshTokenId { get; set; }
    }
}
