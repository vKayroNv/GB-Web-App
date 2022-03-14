using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheets.API.Models
{
    public class EmployeeModel : EntityModel
    {
        public Guid UserId { get; set; }
    }
}
