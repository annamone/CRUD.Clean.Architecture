using AutoMapper;
using CredoTasks.CRUD.Application.Contracts.Persistence;
using CredoTasks.CRUD.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CredoTasks.CRUD.Application.Features.Persons.Queries.GetPersonList
{
    public class GetPersonListQueryHandler : IRequestHandler<GetPersonListQuery, IEnumerable<PersonListViewModel>>
    {
        private readonly IAsyncRepository<Person> _personRepository;
        private readonly IMapper _mapper;
        public GetPersonListQueryHandler(IMapper mapper, IAsyncRepository<Person> personRepository)
        {
            _mapper = mapper;
            _personRepository= personRepository;
        }
        public async Task<IEnumerable<PersonListViewModel>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
        {
            var allPersons = (await _personRepository.GetAllAsync());
            return _mapper.Map<IEnumerable<PersonListViewModel>>(allPersons);
        }
    }
}
