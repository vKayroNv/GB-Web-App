using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Domain.Aggregates;
using Timesheets.Domain.Interfaces;
using Timesheets.Domain.Models;

namespace Timesheets.Domain.Managers
{
    public class InvoiceManager : IInvoiceManager
    {
        private readonly IInvoiceRepository _repository;

        public InvoiceManager(IInvoiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Create(DateTime dateStart, DateTime dateEnd, CancellationToken cts)
        {
            var sheet = InvoiceAggregate.Create(dateStart, dateEnd);

            await _repository.Create(sheet, cts);

            return true;
        }

        public async Task<Invoice> Read(Guid id, CancellationToken cts)
        {
            return await _repository.Read(id, cts);
        }

        public async Task<IReadOnlyCollection<Invoice>> Read(CancellationToken cts)
        {
            return await _repository.Read(cts);
        }

        public async Task<bool> IncludeSheets(Guid invoiceId, IEnumerable<Sheet> sheets, CancellationToken cts)
        {
            try
            {
                var invoice = InvoiceAggregate.ToAggregate(await Read(invoiceId, cts));
                invoice.IncludeSheets(sheets);
                await _repository.Update(invoice, cts);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
