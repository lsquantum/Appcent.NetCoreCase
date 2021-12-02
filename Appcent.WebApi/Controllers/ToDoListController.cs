using Appcent.Application.Features.ToDoLists.Commands.CreateToDoList;
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
        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateToDoListCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
