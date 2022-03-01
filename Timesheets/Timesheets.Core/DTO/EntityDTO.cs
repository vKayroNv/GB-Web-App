using System;

namespace Timesheets.Core.DTO
{
    public class EntityDTO
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Comment { get; set; }
    }

}
