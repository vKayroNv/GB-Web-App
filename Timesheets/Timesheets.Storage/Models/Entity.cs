using System;
using System.ComponentModel.DataAnnotations;

namespace Timesheets.Storage.Models
{
    public class Entity
    {
        [Required]
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Comment { get; set; }
    }

}
