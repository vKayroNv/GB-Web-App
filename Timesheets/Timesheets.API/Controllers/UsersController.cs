using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Timesheers.Entities.Requests;
using Timesheets.Interfaces.Services;

namespace Timesheets.API.Controllers
{
    [Route("[controller]")]
    [Authorize]
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
        /// <response code="401">Недостаточно прав</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRequest entity, CancellationToken cts)
        {
            var result = await _dataService.Create(entity, cts);

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
        /// <response code="401">Недостаточно прав</response>
        [HttpGet]
        public async Task<IActionResult> Read(CancellationToken cts)
        {
            var result = await _dataService.Read(cts);

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
        /// <response code="401">Недостаточно прав</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> Read([FromRoute] Guid id, CancellationToken cts)
        {
            var result = await _dataService.Read(id, cts);

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
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="entity">Обновленные данные пользователя</param>
        /// <param name="cts"></param>
        /// <response code="400">Введены неверные данные</response>
        /// <response code="401">Недостаточно прав</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UserRequest entity, CancellationToken cts)
        {
            var result = await _dataService.Update(id, entity, cts);

            if (result)
            {
                return Ok(entity);
            }
            else
            {
                return BadRequest(id);
            }
        }

        /// <summary>
        /// Удаление пользователя из базы данных
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="cts"></param>
        /// <response code="400">Введен неверный идентификатор</response>
        /// <response code="401">Недостаточно прав</response>
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
