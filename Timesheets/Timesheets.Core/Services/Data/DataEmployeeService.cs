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
    public class DataEmployeeService : IDataEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public DataEmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Create(EmployeeRequest entity, CancellationToken cts)
        {
            var dto = new EmployeeDTO()
            {
                Id = Guid.NewGuid(),
                UserId = entity.UserId,
                Comment = entity.Comment
            };

            return await _repository.Create(_mapper.Map<Employee>(dto), cts);
        }

        public async Task<IReadOnlyCollection<EmployeeResponse>> Read(CancellationToken cts)
        {
            var entitiesList = _mapper.Map<IReadOnlyCollection<EmployeeDTO>>(await _repository.Read(cts));

            List<EmployeeResponse> responsesList = new List<EmployeeResponse>();

            foreach (var entity in entitiesList)
            {
                responsesList.Add(new EmployeeResponse()
                {
                    Id = entity.Id,
                    UserId = entity.UserId,
                    Comment = entity.Comment
                });
            }

            return responsesList;
        }

        public async Task<EmployeeResponse> Read(Guid id, CancellationToken cts)
        {
            var entity = _mapper.Map<EmployeeDTO>(await _repository.Read(id, cts));

            return new EmployeeResponse()
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Comment = entity.Comment
            };
        }

        public async Task<bool> Update(Guid id, EmployeeRequest entity, CancellationToken cts)
        {
            var dto = new EmployeeDTO()
            {
                Id = id,
                UserId = entity.UserId,
                Comment = entity.Comment
            };

            return await _repository.Update(_mapper.Map<Employee>(dto), cts);
        }

        public async Task<bool> Delete(Guid id, CancellationToken cts)
        {
            return await _repository.Delete(id, cts);
        }
    }
}
