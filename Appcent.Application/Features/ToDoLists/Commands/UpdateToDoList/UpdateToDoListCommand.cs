using Appcent.Application.Exceptions;
using Appcent.Application.Interfaces;
using Appcent.Application.Wrappers;
using Appcent.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Appcent.Application.Features.ToDoLists.Commands.UpdateToDoList
{
    public class UpdateToDoListCommand : IRequest<Response<string>>
    {
        public string Key { get; set; }
        public string TaskName { get; set; }
        public Status TaskStatus { get; set; }
        public class UpdateToDoListCommandHandler : IRequestHandler<UpdateToDoListCommand, Response<string>>
        {
            private readonly IToDoListRepositoryAsync _toDoListRepository;
            public UpdateToDoListCommandHandler(IToDoListRepositoryAsync toDoListRepository)
            {
                _toDoListRepository = toDoListRepository;
            }
            public async Task<Response<string>> Handle(UpdateToDoListCommand command, CancellationToken cancellationToken)
            {
                var toDoList = await _toDoListRepository.GetByIdAsync(command.Key);
                if (toDoList == null) throw new ApiException($"ToDoList Not Found.");
                else
                {
                    toDoList.TaskName = command.TaskName;
                    toDoList.TaskStatus = command.TaskStatus;
                    await _toDoListRepository.UpdateAsync(toDoList);
                    return new Response<string>($"ToDo object with Key:{command.Key} successfully updated.");
                }
            }
        }
    }
}
