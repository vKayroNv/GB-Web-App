using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Storage.Interfaces;
using Timesheets.Storage.Models;

namespace Timesheets.API.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Добавление нового пользователя в базу данных
        /// </summary>
        /// <param name="entity">Новый пользователь</param>
        /// <param name="cts"></param>
        /// <response code="400">Введены неверные данные</response>
        /// <response code="401">Недостаточно прав</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User entity, CancellationToken cts)
        {
            var result = await _repository.Create(entity, cts);

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
            var result = await _repository.Read(cts);

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
            var result = await _repository.Read(id, cts);

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
        /// <response code="401">Недостаточно прав</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] User entity, CancellationToken cts)
        {
            var result = await _repository.Update(entity, cts);

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
        /// <response code="401">Недостаточно прав</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cts)
        {
            var result = await _repository.Delete(id, cts);

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
