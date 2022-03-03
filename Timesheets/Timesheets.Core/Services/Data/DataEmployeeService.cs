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
    public class DataEmployeeService : IDataEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public DataEmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Create(EmployeeDTO entity, CancellationToken cts)
        {
            return await _repository.Create(_mapper.Map<Employee>(entity), cts); ;
        }

        public async Task<IReadOnlyCollection<EmployeeDTO>> Read(CancellationToken cts)
        {
            return _mapper.Map<IReadOnlyCollection<EmployeeDTO>>(await _repository.Read(cts));
        }

        public async Task<EmployeeDTO> Read(Guid id, CancellationToken cts)
        {
            return _mapper.Map<EmployeeDTO>(await _repository.Read(id, cts));
        }

        public async Task<bool> Update(EmployeeDTO entity, CancellationToken cts)
        {
            return await _repository.Update(_mapper.Map<Employee>(entity), cts);
        }

        public async Task<bool> Delete(Guid id, CancellationToken cts)
        {
            return await _repository.Delete(id, cts);
        }
    }
}
