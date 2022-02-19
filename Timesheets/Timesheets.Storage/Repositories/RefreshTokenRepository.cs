using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Storage.EF;
using Timesheets.Storage.Interfaces;
using Timesheets.Storage.Models;

namespace Timesheets.Storage.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly DatabaseContext _context;

        public RefreshTokenRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(RefreshToken token, CancellationToken cts)
        {
            try
            {
                await _context.Tokens.AddAsync(token, cts);
                await _context.SaveChangesAsync(cts);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<RefreshToken> Get(Guid id, CancellationToken cts)
        {
            return await _context.Tokens.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<RefreshToken> Get(string token, CancellationToken cts)
        {
            return await _context.Tokens.FirstOrDefaultAsync(s => s.Token == token);
        }

        public async Task<bool> Remove(Guid id, CancellationToken cts)
        {
            try
            {
                var obj = await Get(id, cts);
                _context.Tokens.Remove(obj);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
