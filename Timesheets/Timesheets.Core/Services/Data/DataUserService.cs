using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheers.Entities.Requests;
using Timesheers.Entities.Responses;
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

        public async Task<bool> Create(UserRequest entity, CancellationToken cts)
        {
            var dto = new UserDTO()
            {
                Id = Guid.NewGuid(),
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age,
                Comment = entity.Comment
            };

            return await _repository.Create(_mapper.Map<User>(dto), cts);
        }

        public async Task<IReadOnlyCollection<UserResponse>> Read(CancellationToken cts)
        {
            var entitiesList = _mapper.Map<IReadOnlyCollection<UserDTO>>(await _repository.Read(cts));

            List<UserResponse> responsesList = new List<UserResponse>();

            foreach (var entity in entitiesList)
            {
                responsesList.Add(new UserResponse()
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Age = entity.Age,
                    Comment = entity.Comment
                });
            }

            return responsesList;
        }

        public async Task<UserResponse> Read(Guid id, CancellationToken cts)
        {
            var entity = _mapper.Map<UserDTO>(await _repository.Read(id, cts));

            return new UserResponse()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age,
                Comment = entity.Comment
            };
        }

        public async Task<bool> Update(Guid id, UserRequest entity, CancellationToken cts)
        {
            var dto = new UserDTO()
            {
                Id = id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age,
                Comment = entity.Comment
            };

            return await _repository.Update(_mapper.Map<User>(dto), cts);
        }

        public async Task<bool> Delete(Guid id, CancellationToken cts)
        {
            return await _repository.Delete(id, cts);
        }
    }
}
