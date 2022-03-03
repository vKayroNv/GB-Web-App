using System;

namespace Timesheets.Entities.VievModels
{
    public class EntityModel
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Comment { get; set; }
    }

}
