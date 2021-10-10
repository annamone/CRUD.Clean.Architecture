using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredoTasks.CRUD.Application.Features.Persons.Commands.DeletePerson
{
    public class DeletePersonCommand : IRequest
    {
        public int Id;
    }
}
