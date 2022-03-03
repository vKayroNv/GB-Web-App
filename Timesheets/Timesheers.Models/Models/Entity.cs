using System;
using System.ComponentModel.DataAnnotations;

namespace Timesheets.Entities.Models
{
    public class Entity
    {
        [Required]
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Comment { get; set; }
    }

}
