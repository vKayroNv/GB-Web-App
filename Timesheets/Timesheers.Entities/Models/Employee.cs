using System;
using System.ComponentModel.DataAnnotations;

namespace Timesheets.Entities.Models
{
    public sealed class Employee : Entity
    {
        [Required]
        public Guid UserId { get; set; }
    }
}
