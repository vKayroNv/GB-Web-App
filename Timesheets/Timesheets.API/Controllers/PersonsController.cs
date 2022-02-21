using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Core.Interfaces;
using Timesheets.Core.Models;

namespace Timesheets.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonRepository _personRepository;

        public PersonsController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        /// <summary>
        /// Получение человека по идентификатору
        /// </summary>
        /// <param name="id">Id человека</param>
        /// <param name="cancellationToken"></param>
        /// <response code="400">Человек по идентификатору не найден</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPersonById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var result = await _personRepository.GetPersonById(id, cancellationToken);

            if (result == null)
                return BadRequest(id);
            
            return Ok(result);
        }

        /// <summary>
        /// Поиск человека по имени
        /// </summary>
        /// <param name="searchTerm">Имя человека</param>
        /// <param name="cancellationToken"></param>
        [HttpGet("search")]
        public async Task<ActionResult> GetPersonsByName([FromQuery] string searchTerm, CancellationToken cancellationToken)
        {
            var result = await _personRepository.GetPersonsByName(searchTerm, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Получение списка людей с пагинацией
        /// </summary>
        /// <param name="skip">Сколько пропустить от начала списка</param>
        /// <param name="take">Сколько взять</param>
        /// <param name="cancellationToken"></param>
        [HttpGet]
        public async Task<ActionResult> GetPersonsWithPagination([FromQuery] int skip, [FromQuery] int take, CancellationToken cancellationToken)
        {
            var result = await _personRepository.GetPersonsWithPagination(skip, take, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Добавление нового человека в коллекцию
        /// </summary>
        /// <param name="person">Новый человек</param>
        /// <param name="cancellationToken"></param>
        /// <response code="400">Введены неверные данные</response>
        [HttpPost]
        public async Task<ActionResult> AddPerson([FromBody] Person person, CancellationToken cancellationToken)
        {
            var result = await _personRepository.AddPerson(person, cancellationToken);

            if (result)
                return Ok(person);
            else
                return BadRequest(person);
        }

        /// <summary>
        /// Обновление существующего человека в коллекции
        /// </summary>
        /// <param name="person">Обновление данных о человеке, где id в новых данных = id существующего человека</param>
        /// <param name="cancellationToken"></param>
        /// <response code="400">Человек по идентификатору не найден или введены неверные данные</response>
        [HttpPut]
        public async Task<ActionResult> UpdatePerson([FromBody] Person person, CancellationToken cancellationToken)
        {
            var result = await _personRepository.UpdatePerson(person, cancellationToken);

            if (result)
                return Ok(person);
            else
                return BadRequest(person);
        }

        /// <summary>
        /// Удаление человека из коллекции
        /// </summary>
        /// <param name="id">Id человека</param>
        /// <param name="cancellationToken"></param>
        /// <response code="400">Человек по идентификатору не найден</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerson([FromRoute] int id, CancellationToken cancellationToken)
        {
            var result = await _personRepository.DeletePerson(id, cancellationToken);

            if (result)
                return Ok(id);
            else
                return BadRequest(id);
        }
    }
}
