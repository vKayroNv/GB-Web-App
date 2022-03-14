using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheets.Storage.Models
{
    [Table("employees")]
    public sealed class Employee : Entity
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
