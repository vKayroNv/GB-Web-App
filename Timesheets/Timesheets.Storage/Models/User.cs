using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheets.Storage.Models
{
    [Table("users")]
    public class User : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
