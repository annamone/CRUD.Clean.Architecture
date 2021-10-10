using CredoTasks.CRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredoTasks.CRUD.Application.Contracts.Persistence
{
    public interface IPersonRepository : IAsyncRepository<Person>
    {
        Task<Person> GetPersonByPersonalNumber(string personalNumber);
    }
}
