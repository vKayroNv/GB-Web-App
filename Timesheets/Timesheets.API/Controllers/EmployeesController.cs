using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.API.Models;
using Timesheets.Core.DTO;
using Timesheets.Core.Interfaces;

namespace Timesheets.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IDataEmployeeService _dataService;
        private readonly IMapper _mapper;

        public EmployeesController(IDataEmployeeService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        /// <summary>
        /// Добавление нового сотрудника в базу данных
        /// </summary>
        /// <param name="entity">Новый сотрудник</param>
        /// <param name="cts"></param>
        /// <response code="400">Введены неверные данные</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeModel entity, CancellationToken cts)
        {
            var result = await _dataService.Create(_mapper.Map<EmployeeDTO>(entity), cts);

            if (result)
            {
                return Ok(entity);
            }
            else
            {
                return BadRequest(entity);
            }
        }

        /// <summary>
        /// Получение сотрудников из базы данных
        /// </summary>
        /// <param name="cts"></param>
        /// <response code="400">Введен неверный идентификатор</response>
        [HttpGet]
        public async Task<IActionResult> Read(CancellationToken cts)
        {
            var result = _mapper.Map<IReadOnlyCollection<EmployeeModel>>(await _dataService.Read(cts));

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Получение сотрудника из базы данных
        /// </summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <param name="cts"></param>
        /// <response code="400">Введен неверный идентификатор</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> Read([FromRoute] Guid id, CancellationToken cts)
        {
            var result = _mapper.Map<EmployeeModel>(await _dataService.Read(id, cts));

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(id);
            }
        }

        /// <summary>
        /// Обновление информации о сотруднике в базе данных
        /// </summary>
        /// <param name="entity">Обновленные данные сотрудника, где id в новых данных совпадает с id в базе</param>
        /// <param name="cts"></param>
        /// <response code="400">Введены неверные данные</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EmployeeModel entity, CancellationToken cts)
        {
            var result = await _dataService.Update(_mapper.Map<EmployeeDTO>(entity), cts);

            if (result)
            {
                return Ok(entity);
            }
            else
            {
                return BadRequest(entity.Id);
            }
        }

        /// <summary>
        /// Удаление сотрудника из базы данных
        /// </summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <param name="cts"></param>
        /// <response code="400">Введен неверный идентификатор</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cts)
        {
            var result = await _dataService.Delete(id, cts);

            if (result)
            {
                return Ok(id);
            }
            else
            {
                return BadRequest(id);
            }
        }
    }
}
