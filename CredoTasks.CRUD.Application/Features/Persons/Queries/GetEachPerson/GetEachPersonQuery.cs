using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredoTasks.CRUD.Application.Features.Persons.Queries.GetEachPerson
{
    public class GetEachPersonQuery : IRequest<EachPersonViewModel>
    {
        public int Id { get; set; }
    }
}
