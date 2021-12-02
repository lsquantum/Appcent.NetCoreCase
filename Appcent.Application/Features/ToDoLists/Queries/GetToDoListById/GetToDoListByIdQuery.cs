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

namespace Appcent.Application.Features.ToDoLists.Queries.GetToDoListById
{
    public class GetToDoListByIdQuery : IRequest<Response<ToDoList>>
    {
        public string Key { get; set; }
        public class GetToDoListByIdQueryHandler : IRequestHandler<GetToDoListByIdQuery, Response<ToDoList>>
        {
            private readonly IToDoListRepositoryAsync _toDoListRepository;
            public GetToDoListByIdQueryHandler(IToDoListRepositoryAsync toDoListRepository)
            {
                _toDoListRepository = toDoListRepository;
            }
            public async Task<Response<ToDoList>> Handle(GetToDoListByIdQuery query, CancellationToken cancellationToken)
            {
                var ToDoList = await _toDoListRepository.GetByIdAsync(query.Key);
                if (ToDoList == null) throw new ApiException($"ToDoList Not with Key:{query.Key} Found.");
                return new Response<ToDoList>(ToDoList);
            }
        }
    }
}
