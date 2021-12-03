using Appcent.Application.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appcent.Application.Features.Users.Command.AuthenticateUser
{
    public class AuthenticateUserCommandValidator : AbstractValidator<AuthenticateUserCommand>
    {
        private readonly IUserRepositoryAsync userRepository;
        public AuthenticateUserCommandValidator(IUserRepositoryAsync userRepository)
        {
            this.userRepository = userRepository;

            RuleFor(p => p.Email)
                .EmailAddress()
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
