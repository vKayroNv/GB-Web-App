using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Timesheets.Domain.Aggregates;

namespace Timesheets.Domain.Models
{
	public class Sheet
	{
		public Guid Id { get; set; }

		public DateTime ApproveDate { get; set; }

		public bool IsApproved { get; set; }
    }
}