using Appcent.Application.Interfaces;
using Appcent.Application.Wrappers;
using Appcent.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Appcent.Application.Features.Users.Command.RegisterUser
{
    public partial class RegisterUserCommand : IRequest<Response<string>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class AuthenticateUserCommandHandler : IRequestHandler<RegisterUserCommand, Response<string>>
    {
        private readonly IUserRepositoryAsync _userRepository;
        private readonly IMapper _mapper;
        public AuthenticateUserCommandHandler(IUserRepositoryAsync userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            var key = await _userRepository.AddAsync(user);
            return new Response<string>($"New User object added with key:{key}");
        }
    }
}
