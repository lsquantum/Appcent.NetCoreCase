using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appcent.WebApi.Controllers
{
    public class AuthController : BaseApiController
    {
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
