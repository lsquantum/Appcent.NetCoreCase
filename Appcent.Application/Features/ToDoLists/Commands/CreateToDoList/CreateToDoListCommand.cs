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

namespace Appcent.Application.Features.ToDoLists.Commands.CreateToDoList
{
    public partial class CreateToDoListCommand : IRequest<Response<string>>
    {
        public string TaskName { get; set; }
    }
    public class CreateToDoListCommandHandler : IRequestHandler<CreateToDoListCommand, Response<string>>
    {
        private readonly IToDoListRepositoryAsync _toDoListRepository;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _user;
        public CreateToDoListCommandHandler(IToDoListRepositoryAsync toDoListRepository, IMapper mapper, IAuthenticatedUserService user)
        {
            _toDoListRepository = toDoListRepository;
            _mapper = mapper;
            _user = user;
        }

        public async Task<Response<string>> Handle(CreateToDoListCommand request, CancellationToken cancellationToken)
        {
            var objectId = Guid.NewGuid().ToString();
            var toDoList = _mapper.Map<ToDoList>(request);
            toDoList.ObjectId = objectId;
            toDoList.UserId = _user.UserId;
            var key = await _toDoListRepository.AddAsync(objectId, toDoList);
            return new Response<string>($"New ToDo object added with key:{key}");
        }
    }
}