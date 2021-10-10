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

namespace CredoTasks.CRUD.Application.Features.Persons.Commands.UpdatePerson
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
    {
        private readonly IAsyncRepository<Person> _personRepository;
        private readonly IMapper _mapper;
        public UpdatePersonCommandHandler(IMapper mapper, IAsyncRepository<Person> personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }
        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var personToUpdate = await _personRepository.GetByIdAsync(request.Id);

            if (personToUpdate == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }

            var validator = new UpdatePersonCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, personToUpdate, typeof(UpdatePersonCommand), typeof(Person));

            await _personRepository.UpdateAsync(personToUpdate);

            return Unit.Value;
        }
    }
}
