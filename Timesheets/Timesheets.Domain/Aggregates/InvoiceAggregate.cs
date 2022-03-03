using System;
using System.Collections.Generic;
using System.Text;
using Timesheets.Domain.Models;

namespace Timesheets.Domain.Aggregates
{
    public class InvoiceAggregate : Invoice
    {
        private InvoiceAggregate() { }

        public void IncludeSheets(IEnumerable<Sheet> sheets)
        {
            Sheets.AddRange(sheets);
        }

        public static InvoiceAggregate Create(DateTime dateStart, DateTime dateEnd)
        {
            return new InvoiceAggregate()
            {
                Id = Guid.NewGuid(),
                DateStart = dateStart,
                DateEnd = dateEnd
            };
        }

        public static InvoiceAggregate ToAggregate(Invoice invoice)
        {
            return new InvoiceAggregate()
            {
                Id = invoice.Id,
                DateStart = invoice.DateStart,
                DateEnd = invoice.DateEnd
            };
        }
    }
}
