using AutoMapper;
using CredoTasks.CRUD.Application.Features.Persons.Commands.CreatePerson;
using CredoTasks.CRUD.Application.Features.Persons.Commands.DeletePerson;
using CredoTasks.CRUD.Application.Features.Persons.Commands.UpdatePerson;
using CredoTasks.CRUD.Application.Features.Persons.Queries.GetEachPerson;
using CredoTasks.CRUD.Application.Features.Persons.Queries.GetPersonList;
using CredoTasks.CRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredoTasks.CRUD.Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Person, PersonListViewModel>().ReverseMap();
            CreateMap<Person, CreatePersonCommand>().ReverseMap();
            CreateMap<Person, DeletePersonCommand>().ReverseMap();
            CreateMap<Person, UpdatePersonCommand>().ReverseMap();
            CreateMap<Person, EachPersonViewModel>().ReverseMap();
        }
    }
}
