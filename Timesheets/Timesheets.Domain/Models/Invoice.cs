using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheets.Domain.Models
{
    public class Invoice
	{
        public Guid Id { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public List<Sheet> Sheets { get; set; } = new List<Sheet>();
    }
}
