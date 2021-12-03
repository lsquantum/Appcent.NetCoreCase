using Appcent.Application.Features.ToDoLists.Commands.CreateToDoList;
using Appcent.Application.Features.ToDoLists.Queries.GetAllToDoLists;
using Appcent.Application.Features.Users.Command.RegisterUser;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = Appcent.Domain.Entities;

namespace Appcent.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            //ToDoList Mapping
            CreateMap<CreateToDoListCommand, Entity.ToDoList>();
            CreateMap<Entity.ToDoList, GetAllToDoListsViewModel>().ReverseMap();

            //User Mapping
            CreateMap<RegisterUserCommand, Entity.User>();
        }
    }
}
