using System;
using System.Collections.Generic;

namespace Timesheets.Entities.Models
{
    public class Invoice
    {
        public Guid Id { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public List<Sheet> Sheets { get; set; } = new List<Sheet>();
    }
}
