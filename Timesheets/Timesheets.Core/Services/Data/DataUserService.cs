using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Entities.DTO;
using Timesheets.Entities.Models;
using Timesheets.Interfaces.Repositories;
using Timesheets.Interfaces.Services;

namespace Timesheets.Core.Services.Data
{
    public class DataUserService : IDataUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public DataUserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Create(UserDTO entity, CancellationToken cts)
        {
            return await _repository.Create(_mapper.Map<User>(entity), cts);
        }

        public async Task<IReadOnlyCollection<UserDTO>> Read(CancellationToken cts)
        {
            return _mapper.Map<IReadOnlyCollection<UserDTO>>(await _repository.Read(cts));
        }

        public async Task<UserDTO> Read(Guid id, CancellationToken cts)
        {
            return _mapper.Map<UserDTO>(await _repository.Read(id, cts));
        }

        public async Task<bool> Update(UserDTO entity, CancellationToken cts)
        {
            return await _repository.Update(_mapper.Map<User>(entity), cts);
        }

        public async Task<bool> Delete(Guid id, CancellationToken cts)
        {
            return await _repository.Delete(id, cts);
        }
    }
}
