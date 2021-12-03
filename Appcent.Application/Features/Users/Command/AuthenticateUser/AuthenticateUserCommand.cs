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

namespace Appcent.Application.Features.Users.Command.AuthenticateUser
{
    public partial class AuthenticateUserCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class AuthenticationResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string JWToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, Response<string>>
    {
        private readonly IUserRepositoryAsync _userRepository;
        private readonly IMapper _mapper;
        public AuthenticateUserCommandHandler(IUserRepositoryAsync userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
