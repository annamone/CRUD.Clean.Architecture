using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredoTasks.CRUD.Application.Features.Persons.Queries.GetPersonList
{
    public class GetPersonListQuery : IRequest<IEnumerable<PersonListViewModel>>
    {
        
    }
}
