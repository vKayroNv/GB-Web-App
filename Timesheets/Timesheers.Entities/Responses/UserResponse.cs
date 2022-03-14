using System;

namespace Timesheers.Entities.Responses
{
    public class UserResponse
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Comment { get; set; }
    }
}
