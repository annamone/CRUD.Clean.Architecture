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

namespace CredoTasks.CRUD.Application.Features.Persons.Queries.GetEachPerson
{
    public class GetEachPersonQueryHandler : IRequestHandler<GetEachPersonQuery, EachPersonViewModel>
    {
        private readonly IAsyncRepository<Person> _personRepository;
        private readonly IMapper _mapper;
        public GetEachPersonQueryHandler(IMapper mapper, IAsyncRepository<Person> personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }
        public async Task<EachPersonViewModel> Handle(GetEachPersonQuery request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetByIdAsync(request.Id);
            if(person == null)
            {
                throw new NotFoundException(nameof(Person),request.Id);
            }
            var personDto = _mapper.Map<EachPersonViewModel>(person);

            return personDto;
        }
    }
}
