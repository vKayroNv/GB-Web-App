﻿namespace Timesheets.API.Models
{
    public class UserModel : EntityModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
