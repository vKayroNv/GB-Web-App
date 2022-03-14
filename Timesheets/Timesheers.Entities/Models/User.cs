using System.ComponentModel.DataAnnotations;

namespace Timesheets.Entities.Models
{
    public sealed class User : Entity
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
    }
}
