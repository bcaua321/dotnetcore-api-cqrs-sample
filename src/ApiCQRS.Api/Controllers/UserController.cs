using ApiCQRS.Api.HttpResult;
using ApiCQRS.Application.Commands.UserCommands.DTOs;
using ApiCQRS.Application.Queries.UserQueries.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiCQRS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUser(Guid id) 
        {
            var getUserByIdCommand = new GetUserByIdCommand { Id = id };
            var response = await _mediator.Send(getUserByIdCommand);

            return new Result().Execute(response);
        }

        [HttpPost("CreateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUser(RegisterUserCommand registerUserCommand) 
        {
            var response = await _mediator.Send(registerUserCommand);
            
            return new Result().Execute(response);
        }

        [HttpPut("UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand updateUserCommand) 
        {
            var response = await _mediator.Send(updateUserCommand);

            return new Result().Execute(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUser(Guid id) 
        {
            var deleteUserCommand = new DeleteUserCommand { Id = id };
            var response = await _mediator.Send(deleteUserCommand);

            return new Result().Execute(response);
        }
    }
}