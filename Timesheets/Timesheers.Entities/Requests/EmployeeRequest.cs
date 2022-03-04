using System;
using System.ComponentModel.DataAnnotations;

namespace Timesheers.Entities.Requests
{
    public class EmployeeRequest
    {
        [Required]
        public Guid UserId { get; set; }

        public string Comment { get; set; }
    }
}
