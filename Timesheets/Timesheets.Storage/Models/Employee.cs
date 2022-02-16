using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Timesheets.Storage.Models
{
    [Table("employees")]
    public class Employee : Entity
    {
        public Guid UserId { get; set; }
    }
}
