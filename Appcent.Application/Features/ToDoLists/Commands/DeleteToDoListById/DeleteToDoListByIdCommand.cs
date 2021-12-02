using Appcent.Application.Exceptions;
using Appcent.Application.Interfaces;
using Appcent.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Appcent.Application.Features.ToDoLists.Commands.DeleteToDoListById
{
    public class DeleteToDoListByIdCommand : IRequest<Response<string>>
    {
        public string Key { get; set; }
        public class DeleteToDoListByIdCommandHandler : IRequestHandler<DeleteToDoListByIdCommand, Response<string>>
        {
            private readonly IToDoListRepositoryAsync _toDoListRepository;
            public DeleteToDoListByIdCommandHandler(IToDoListRepositoryAsync toDoListRepository)
            {
                _toDoListRepository = toDoListRepository;
            }
            public async Task<Response<string>> Handle(DeleteToDoListByIdCommand command, CancellationToken cancellationToken)
            {
                var toDoList = await _toDoListRepository.GetByIdAsync(command.Key);
                if (toDoList == null) throw new ApiException($"ToDoList Not Found with Key:{command.Key}");
                await _toDoListRepository.DeleteAsync(toDoList);
                return new Response<string>($"ToDo object deleted with Key:{command.Key}");
            }
        }
    }
}
