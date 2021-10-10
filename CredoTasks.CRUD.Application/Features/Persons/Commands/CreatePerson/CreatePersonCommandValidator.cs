using CredoTasks.CRUD.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredoTasks.CRUD.Application.Features.Persons.Commands.CreatePerson
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        private readonly IPersonRepository _personRepository;

        public CreatePersonCommandValidator(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(p => p.PersonalNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .Length(11).WithMessage("{PropertyName} must have only 11 characters");

            RuleFor(p => p.BirthDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .Must(BirthDateValid).WithMessage("Age must between 15 and 60");
        }
        private bool BirthDateValid(DateTime date)
        {
            int currentYear = DateTime.Now.Year;
            int dobYear = date.Year;

            if (dobYear <= currentYear && dobYear > (currentYear - 60) && dobYear < (currentYear - 15))
            {
                return true;
            }
            return false;
        }
    }
}
