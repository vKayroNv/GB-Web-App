using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheets.Storage.Models
{
    [Table("employees")]
    public class Employee : Entity
    {
        public Guid UserId { get; set; }
    }
}
