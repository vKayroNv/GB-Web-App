using System;

namespace Timesheets.Entities.Models
{
    public class Sheet
    {
        public Guid Id { get; set; }

        public DateTime ApproveDate { get; set; }

        public bool IsApproved { get; set; }
    }
}