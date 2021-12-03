using Appcent.Application.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Appcent.Application.Features.Users.Command.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        private readonly IUserRepositoryAsync userRepository;
        public RegisterUserCommandValidator(IUserRepositoryAsync userRepository)
        {
            this.userRepository = userRepository;

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MinimumLength(2).WithMessage("{PropertyName} must be longer than 2 characters.");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();            
            
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(IsUniqueBarcode).WithMessage("{PropertyName} already exists.");            
            
            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }

        private async Task<bool> IsUniqueBarcode(string email, CancellationToken cancellationToken)
        {
            return await userRepository.IsUniqueEmailAsync(email);
        }
    }
}