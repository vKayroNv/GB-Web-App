using System;
using Timesheets.Domain.Models;

namespace Timesheets.Domain.Aggregates
{
    public class SheetAggregate : Sheet
    {
        private SheetAggregate() { }

        public void ApproveSheet()
        {
            IsApproved = true;
            ApproveDate = DateTime.Now;
        }

        public static SheetAggregate Create(DateTime date)
        {
            return new SheetAggregate()
            {
                Id = Guid.NewGuid()
            };
        }

        public static SheetAggregate ToAggregate(Sheet sheet)
        {
            return new SheetAggregate()
            {
                Id = sheet.Id,
                ApproveDate = sheet.ApproveDate,
                IsApproved = sheet.IsApproved
            };
        }
    }
}
