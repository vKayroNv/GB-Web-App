using System;
using System.ComponentModel.DataAnnotations;

namespace Timesheers.Entities.Requests
{
    public class UserRequest
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Range(1, 100)]
        public int Age { get; set; }

        public string Comment { get; set; }
    }
}
