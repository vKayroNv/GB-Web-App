using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheets.Storage.Models
{
    [Table("users")]
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
