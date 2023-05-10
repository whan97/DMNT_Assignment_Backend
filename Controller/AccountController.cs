using Demant_Assignment.Application.Command;
using Demant_Assignment.Application.DTO;
using Demant_Assignment.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Demant_Assignment.Application.Controller
{
    [Route("api")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IMediator Mediator { get; }

        public AccountController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost("login")]
        [SwaggerOperation(OperationId = nameof(Login), Tags = new[] { "Demant Assignment" })]
        public async Task<IActionResult> Login([FromBody] LoginDetailsInputDTO inputDTO)
        {
            UserLoginCommand request = new UserLoginCommand
            {
                inputDTO = inputDTO
            };
            var result = await Mediator.Send(request);

            if (result.IsFailure)
            {
                ModelState.AddModelError("Error", result.Error);
                return ValidationProblem(result.Error);
            }
 
            return Ok(result.Value);
        }

        [Authorize]
        [HttpGet("users")]
        [SwaggerOperation(OperationId = nameof(GetAllUsers), Tags = new[] { "Demant Assignment" })]
        public async Task<IActionResult> GetAllUsers()
        {
            GetUsersQuery request = new GetUsersQuery
            {
            };
            var result = await Mediator.Send(request);
            if (result.IsFailure)
            {
                ModelState.AddModelError("Error", result.Error);
                return ValidationProblem(result.Error);
            }
            return Ok(result.Value);
        }
    }
}
