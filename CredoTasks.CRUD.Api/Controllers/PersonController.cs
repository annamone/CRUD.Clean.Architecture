using CredoTasks.CRUD.Application.Features.Persons.Commands.CreatePerson;
using CredoTasks.CRUD.Application.Features.Persons.Commands.DeletePerson;
using CredoTasks.CRUD.Application.Features.Persons.Commands.UpdatePerson;
using CredoTasks.CRUD.Application.Features.Persons.Queries.GetEachPerson;
using CredoTasks.CRUD.Application.Features.Persons.Queries.GetPersonList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredoTasks.CRUD.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonListViewModel>>> GetAllPersons()
        {
            var persons = await _mediator.Send(new GetPersonListQuery());
            return Ok(persons);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EachPersonViewModel>> GetPersonById(int id)
        {
            var eachPerson = await _mediator.Send(new GetEachPersonQuery() { Id = id });
            return eachPerson;
        }
        [HttpPost]
        public async Task<ActionResult<int>> CreatePerson([FromBody] CreatePersonCommand createPersonCommand)
        {
            var id = await _mediator.Send(createPersonCommand);
            return Ok(id);
        }
        [HttpPut]
        public async Task<ActionResult> UpdatePerson([FromBody] UpdatePersonCommand updatePersonCommand)
        {
            await _mediator.Send(updatePersonCommand);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePerson(int id)
        {
            await _mediator.Send(new DeletePersonCommand() { Id = id });
            return NoContent();
        }
    }
}
