using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Storage.EF;
using Timesheets.Storage.Interfaces;
using Timesheets.Storage.Models;

namespace Timesheets.Storage.Repositories
{
    public sealed class LoginRepository : ILoginRepository
    {
        private readonly DatabaseContext _context;

        public LoginRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Login entity, CancellationToken cts)
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

        public async Task<Login> Read(Guid id, CancellationToken cts)
        {
            var result = await _context.Logins.FindAsync(new object[] { id }, cts);

            return result;
        }

        public async Task<Login> Read(string username, CancellationToken cts)
        {
            var result = await _context.Logins.FirstOrDefaultAsync(s => s.Username == username, cts);

            return result;
        }

        public async Task<bool> Update(Login entity, CancellationToken cts)
        {
            var result = await _context.Logins.FirstOrDefaultAsync(s => s.Id == entity.Id, cts);

            if (result == null)
            {
                return false;
            }

            result.Username = entity.Username;
            result.Password = entity.Password;
            result.RefreshTokenId = entity.RefreshTokenId;
            result.Comment = entity.Comment;
            result.IsDeleted = entity.IsDeleted;

            await _context.SaveChangesAsync(cts);

            return true;
        }

        public async Task<bool> Delete(Guid id, CancellationToken cts)
        {
            var result = await _context.Logins.FirstOrDefaultAsync(s => s.Id == id, cts);

            if (result != null)
            {
                _context.Logins.Remove(result);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
