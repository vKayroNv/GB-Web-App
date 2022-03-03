using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Entities.Models;
using Timesheets.Interfaces.Repositories;
using Timesheets.Storage.EF;

namespace Timesheets.Storage.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DatabaseContext _context;

        public InvoiceRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Invoice entity, CancellationToken cts)
        {
            try
            {
                await _context.AddAsync(entity, cts);
                await _context.SaveChangesAsync(cts);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<IReadOnlyCollection<Invoice>> Read(CancellationToken cts)
        {
            return await _context.Invoices.ToArrayAsync();
        }

        public async Task<Invoice> Read(Guid id, CancellationToken cts)
        {
            return await _context.Invoices.FindAsync(new object[] { id }, cts);
        }

        public async Task<bool> Update(Invoice entity, CancellationToken cts)
        {
            var result = await _context.Invoices.FindAsync(new object[] { entity.Id }, cts);

            if (result == null)
            {
                return false;
            }

            result.DateStart = entity.DateStart;
            result.DateEnd = entity.DateEnd;
            result.Sheets = entity.Sheets;

            await _context.SaveChangesAsync(cts);

            return true;
        }

        public async Task<bool> Delete(Guid id, CancellationToken cts)
        {
            var result = await _context.Invoices.FindAsync(new object[] { id }, cts);

            if (result == null)
            {
                return false;
            }

            _context.Invoices.Remove(result);

            return true;
        }
    }
}
