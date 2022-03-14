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
    public sealed class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseContext _context;

        public EmployeeRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Employee entity, CancellationToken cts)
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

        public async Task<IReadOnlyCollection<Employee>> Read(CancellationToken cts)
        {
            var result = await _context.Employees.ToArrayAsync(cts);

            return result;
        }

        public async Task<Employee> Read(Guid id, CancellationToken cts)
        {
            var result = await _context.Employees.FindAsync(new object[] { id }, cts);

            return result;
        }

        public async Task<bool> Update(Employee entity, CancellationToken cts)
        {
            var result = await _context.Employees.SingleOrDefaultAsync(s => s.Id == entity.Id, cts);

            if (result == null)
            {
                return false;
            }

            result.UserId = entity.UserId;
            result.Comment = entity.Comment;

            await _context.SaveChangesAsync(cts);

            return true;
        }

        public async Task<bool> Delete(Guid id, CancellationToken cts)
        {
            var result = await _context.Employees.SingleOrDefaultAsync(s => s.Id == id, cts);

            if (result != null)
            {
                _context.Employees.Remove(result);

                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
