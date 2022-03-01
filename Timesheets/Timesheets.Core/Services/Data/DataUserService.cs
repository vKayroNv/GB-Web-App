using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Core.Interfaces;
using Timesheets.Storage.Interfaces;
using Timesheets.Storage.Models;

namespace Timesheets.Core.Services.Data
{
    public class DataUserService : IDataUserService
    {
        private readonly IUserRepository _repository;

        public DataUserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Create(User entity, CancellationToken cts)
        {
            return await _repository.Create(entity, cts);
        }

        public async Task<IReadOnlyCollection<User>> Read(CancellationToken cts)
        {
            return await _repository.Read(cts);
        }

        public async Task<User> Read(Guid id, CancellationToken cts)
        {
            return await _repository.Read(id, cts); ;
        }

        public async Task<bool> Update(User entity, CancellationToken cts)
        {
            return await _repository.Update(entity, cts);
        }

        public async Task<bool> Delete(Guid id, CancellationToken cts)
        {
            return await _repository.Delete(id, cts);
        }
    }
}
