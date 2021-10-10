using AutoMapper;
using CredoTasks.CRUD.Application.Contracts.Persistence;
using CredoTasks.CRUD.Application.Exceptions;
using CredoTasks.CRUD.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CredoTasks.CRUD.Application.Features.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public CreatePersonCommandHandler(IMapper mapper, IPersonRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }
        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            if(await _personRepository.GetPersonByPersonalNumber(request.PersonalNumber) != null)
            {
                throw new BadRequestException("This Personal Number already exsists.");
            }

            var validator = new CreatePersonCommandValidator(_personRepository);
            var validationResult = validator.Validate(request);
            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var person = _mapper.Map<Person>(request);
            person = await _personRepository.CreateAsync(person);

            return person.Id;
        }
    }
}
