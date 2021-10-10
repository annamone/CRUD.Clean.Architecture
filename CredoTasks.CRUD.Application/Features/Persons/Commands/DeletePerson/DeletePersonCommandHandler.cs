using AutoMapper;
using CredoTasks.CRUD.Application.Contracts.Persistence;
using CredoTasks.CRUD.Application.Exceptions;
using CredoTasks.CRUD.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CredoTasks.CRUD.Application.Features.Persons.Commands.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IAsyncRepository<Person> _personRepository;
        private readonly IMapper _mapper;
        public DeletePersonCommandHandler(IMapper mapper, IAsyncRepository<Person> personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }
        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var personToDelete = await _personRepository.GetByIdAsync(request.Id);

            if(personToDelete == null)
            {
                throw new NotFoundException(nameof(Person),request.Id);
            }
            await _personRepository.DeleteAsync(personToDelete);
            
            return Unit.Value;
        }
    }
}
