using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheets.Storage.Models
{
    [Table("sheets")]
    public sealed class Sheet
	{
		 public Guid Id { get; set; }
		 public DateTime ApproveDate { get; private set;}
		 public bool IsApproved {get; private set;}
		 
		 public void Approve()
		 {
			 IsApproved = true;
			 ApproveDate = DateTime.Now;
		 }
	}
}
