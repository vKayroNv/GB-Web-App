using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Entities.Models;
using Timesheets.Interfaces.Repositories;
using Timesheets.Storage.EF;

namespace Timesheets.Storage.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(User entity, CancellationToken cts)
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

        public async Task<IReadOnlyCollection<User>> Read(CancellationToken cts)
        {
            var result = await _context.Users.Where(s => !s.IsDeleted).ToArrayAsync(cts);

            return result;
        }

        public async Task<User> Read(Guid id, CancellationToken cts)
        {
            var result = await _context.Users.FindAsync(new object[] { id }, cts);

            return result;
        }

        public async Task<bool> Update(User entity, CancellationToken cts)
        {
            var result = await _context.Users.SingleOrDefaultAsync(s => s.Id == entity.Id, cts);

            if (result == null)
            {
                return false;
            }

            result.FirstName = entity.FirstName;
            result.LastName = entity.LastName;
            result.Age = entity.Age;
            result.Comment = entity.Comment;
            result.IsDeleted = entity.IsDeleted;

            await _context.SaveChangesAsync(cts);

            return true;
        }

        public async Task<bool> Delete(Guid id, CancellationToken cts)
        {
            var result = await _context.Users.SingleOrDefaultAsync(s => s.Id == id, cts);

            if (result != null)
            {
                result.IsDeleted = true;

                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
