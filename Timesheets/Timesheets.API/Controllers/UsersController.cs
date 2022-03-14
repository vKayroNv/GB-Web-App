using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.API.Models;
using Timesheets.Core.DTO;
using Timesheets.Core.Interfaces;
using Timesheets.Storage.Models;

namespace Timesheets.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDataUserService _dataService;
        private readonly IMapper _mapper;

        public UsersController(IDataUserService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        /// <summary>
        /// Добавление нового пользователя в базу данных
        /// </summary>
        /// <param name="entity">Новый пользователь</param>
        /// <param name="cts"></param>
        /// <response code="400">Введены неверные данные</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserModel entity, CancellationToken cts)
        {
            var result = await _dataService.Create(_mapper.Map<UserDTO>(entity), cts);

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
        /// Получение пользователей из базы данных
        /// </summary>
        /// <param name="cts"></param>
        /// <response code="400">Введен неверный идентификатор</response>
        [HttpGet]
        public async Task<IActionResult> Read(CancellationToken cts)
        {
            var result = _mapper.Map<IReadOnlyCollection<UserModel>>(await _dataService.Read(cts));

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
        /// Получение пользователя из базы данных
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="cts"></param>
        /// <response code="400">Введен неверный идентификатор</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> Read([FromRoute] Guid id, CancellationToken cts)
        {
            var result = _mapper.Map<UserModel>(await _dataService.Read(id, cts));

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
        /// Обновление информации о пользователе в базе данных
        /// </summary>
        /// <param name="entity">Обновленные данные пользователя, где id в новых данных совпадает с id в базе</param>
        /// <param name="cts"></param>
        /// <response code="400">Введены неверные данные</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserModel entity, CancellationToken cts)
        {
            var result = await _dataService.Update(_mapper.Map<UserDTO>(entity), cts);

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
        /// Удаление пользователя из базы данных
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
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
