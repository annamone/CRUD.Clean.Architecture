using CredoTasks.CRUD.Application.Contracts.Persistence;
using CredoTasks.CRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredoTasks.CRUD.Infrastructure.Repositories
{
    public class PersonRepository : BaseRepository<Person>,IPersonRepository
    {
        public PersonRepository(CredoTasksDbContext dbContext) :base(dbContext)
        {

        }

        public Task<Person> GetPersonByPersonalNumber(string personalNumber)
        {
            return Task.FromResult(_dbContext.Persons.Where(p => p.PersonalNumber == personalNumber).FirstOrDefault());
        }
    }
}
