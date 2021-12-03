using Appcent.Application.Features.ToDoLists.Queries.GetAllToDoLists;
using Appcent.Application.Interfaces;
using Appcent.Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Appcent.Application.Features.ToDoLists.Queries.GetAllToDoListsBuUserId
{
    public class GetAllToDoListsByUserIdQuery : IRequest<Response<IEnumerable<GetAllToDoListsViewModel>>>
    {
        public string Key { get; set; }
        public class GetAllToDoListsByUserIdQueryHandler : IRequestHandler<GetAllToDoListsByUserIdQuery, Response<IEnumerable<GetAllToDoListsViewModel>>>
        {
            private readonly IToDoListRepositoryAsync _toDoListRepository;
            private readonly IMapper _mapper;
            public GetAllToDoListsByUserIdQueryHandler(IToDoListRepositoryAsync toDoListRepository, IMapper mapper)
            {
                _toDoListRepository = toDoListRepository;
                _mapper = mapper;
            }
            public async Task<Response<IEnumerable<GetAllToDoListsViewModel>>> Handle(GetAllToDoListsByUserIdQuery query, CancellationToken cancellationToken)
            {
                var toDoList = await _toDoListRepository.GetAllByUserIdAsync(query.Key);
                var toDoListViewModel = _mapper.Map<IEnumerable<GetAllToDoListsViewModel>>(toDoList);
                return new Response<IEnumerable<GetAllToDoListsViewModel>>(toDoListViewModel);
            }
        }
    }
}
