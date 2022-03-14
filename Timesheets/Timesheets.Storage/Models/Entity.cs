using System;

namespace Timesheets.Storage.Models
{
    public class Entity
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Comment { get; set; }
    }

}
