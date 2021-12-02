using Appcent.Application.Features.ToDoLists.Commands.CreateToDoList;
using Appcent.Application.Features.ToDoLists.Commands.DeleteToDoListById;
using Appcent.Application.Features.ToDoLists.Commands.UpdateToDoList;
using Appcent.Application.Features.ToDoLists.Queries.GetAllToDoLists;
using Appcent.Application.Features.ToDoLists.Queries.GetToDoListById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appcent.WebApi.Controllers
{
    public class ToDoListController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllToDoListsQuery() { }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string key)
        {
            return Ok(await Mediator.Send(new GetToDoListByIdQuery { Key = key }));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateToDoListCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string key, UpdateToDoListCommand command)
        {
            if (string.IsNullOrEmpty(key))
                return BadRequest();
            command.Key = key;
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string key)
        {
            return Ok(await Mediator.Send(new DeleteToDoListByIdCommand { Key = key }));
        }
    }
}
