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
    public class SheetRepository : ISheetRepository
    {
        private readonly DatabaseContext _context;

        public SheetRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Sheet entity, CancellationToken cts)
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

        public async Task<IReadOnlyCollection<Sheet>> Read(CancellationToken cts)
        {
            return await _context.Sheets.ToArrayAsync();
        }

        public async Task<Sheet> Read(Guid id, CancellationToken cts)
        {
            return await _context.Sheets.FindAsync(new object[] { id }, cts);
        }

        public async Task<bool> Update(Sheet entity, CancellationToken cts)
        {
            var result = await _context.Sheets.FindAsync(new object[] { entity.Id }, cts);

            if (result == null)
            {
                return false;
            }

            result.ApproveDate = entity.ApproveDate;
            result.IsApproved = entity.IsApproved;

            await _context.SaveChangesAsync(cts);

            return true;
        }

        public async Task<bool> Delete(Guid id, CancellationToken cts)
        {
            var result = await _context.Sheets.FindAsync(new object[] { id }, cts);

            if (result == null)
            {
                return false;
            }

            _context.Sheets.Remove(result);

            return true;
        }
    }
}
