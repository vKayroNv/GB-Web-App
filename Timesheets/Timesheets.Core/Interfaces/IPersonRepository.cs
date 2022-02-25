using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Timesheets.Core.Models;

namespace Timesheets.Core.Interfaces
{
    public interface IPersonRepository
    {
        public Task<Person> GetPersonById(int id, CancellationToken cancellationToken);

        public Task<IReadOnlyCollection<Person>> GetPersonsByName(string name, CancellationToken cancellationToken);

        public Task<IReadOnlyCollection<Person>> GetPersonsWithPagination(int skip, int take, CancellationToken cancellationToken);

        public Task<bool> AddPerson(Person person, CancellationToken cancellationToken);

        public Task<bool> UpdatePerson(Person person, CancellationToken cancellationToken);

        public Task<bool> DeletePerson(int id, CancellationToken cancellationToken);
    }
}
