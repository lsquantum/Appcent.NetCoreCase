using Appcent.Application.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Appcent.Application.Features.ToDoLists.Commands.CreateToDoList
{
    public class CreateToDoListCommandValidator : AbstractValidator<CreateToDoListCommand>
    {
        private readonly IToDoListRepositoryAsync _toDoListRepository;
        public CreateToDoListCommandValidator(IToDoListRepositoryAsync toDoListRepository)
        {
            RuleFor(p => p.TaskName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MinimumLength(5).WithMessage("{PropertyName} must be longer than 5 characters.");
        }
    }
}
