using Appcent.Application.Features.ToDoLists.Commands.CreateToDoList;
using Appcent.Application.Features.ToDoLists.Commands.DeleteToDoListById;
using Appcent.Application.Features.ToDoLists.Commands.UpdateToDoList;
using Appcent.Application.Features.ToDoLists.Queries.GetAllToDoLists;
using Appcent.Application.Features.ToDoLists.Queries.GetAllToDoListsBuUserId;
using Appcent.Application.Features.ToDoLists.Queries.GetToDoListById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appcent.WebApi.Controllers
{
    [Authorize]
    public class ToDoListController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllToDoListsQuery() { }));
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> Get(string key)
        {
            return Ok(await Mediator.Send(new GetToDoListByIdQuery { Key = key }));
        }

        [HttpGet("GetToDoListsByUserId/{key}")]
        public async Task<IActionResult> GetToDoListsByUserId(string key)
        {
            return Ok(await Mediator.Send(new GetAllToDoListsByUserIdQuery { Key = key }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateToDoListCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{key}")]
        public async Task<IActionResult> Put(string key, UpdateToDoListCommand command)
        {
            if (string.IsNullOrEmpty(key))
                return BadRequest();
            command.Key = key;
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{key}")]
        public async Task<IActionResult> Delete(string key)
        {
            return Ok(await Mediator.Send(new DeleteToDoListByIdCommand { Key = key }));
        }
    }
}
