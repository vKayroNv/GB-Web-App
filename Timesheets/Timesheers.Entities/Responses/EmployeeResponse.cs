using System;

namespace Timesheers.Entities.Responses
{
    public class EmployeeResponse
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Comment { get; set; }
    }
}
