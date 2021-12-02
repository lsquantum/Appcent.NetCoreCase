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

namespace Appcent.Application.Features.ToDoLists.Queries.GetAllToDoLists
{
    public class GetAllToDoListsQuery : IRequest<Response<IEnumerable<GetAllToDoListsViewModel>>>
    {
    }
    public class GetAllToDoListsQueryHandler : IRequestHandler<GetAllToDoListsQuery, Response<IEnumerable<GetAllToDoListsViewModel>>>
    {
        private readonly IToDoListRepositoryAsync _toDoListRepository;
        private readonly IMapper _mapper;
        public GetAllToDoListsQueryHandler(IToDoListRepositoryAsync toDoListRepository, IMapper mapper)
        {
            _toDoListRepository = toDoListRepository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<GetAllToDoListsViewModel>>> Handle(GetAllToDoListsQuery request, CancellationToken cancellationToken)
        {
            var toDoList = await _toDoListRepository.GetAllAsync();
            var toDoListViewModel = _mapper.Map<IEnumerable<GetAllToDoListsViewModel>>(toDoList);
            return new Response<IEnumerable<GetAllToDoListsViewModel>>(toDoListViewModel);
        }
    }
}
