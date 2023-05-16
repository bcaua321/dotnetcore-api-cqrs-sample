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
        // Irá repassar para a classes handlers de queries presentes em ApiCQRS.Application
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

            if(!response.Sucess)
                return NotFound(new { Message = response.Message });

            return Ok(new { User = response.Result });
        }

        [HttpPost("CreateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUser(RegisterUserCommand registerUserCommand) 
        {
            var response = await _mediator.Send(registerUserCommand);
            
            if(!response.Sucess)
                return BadRequest(new { Message = response.Message });

            return Ok(new { Message = response.Message });
        }

        [HttpPut("UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand updateUserCommand) 
        {
            var response = await _mediator.Send(updateUserCommand);

            if(!response.Sucess)
                return BadRequest(new { Message = response.Message });

            return Ok(new { Message = response.Message });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser(Guid id) 
        {
            var deleteUserCommand = new DeleteUserCommand { Id = id };
            var response = await _mediator.Send(deleteUserCommand);

            if(!response.Sucess)
                return BadRequest(new { Message = response.Message });

            return Ok(new { Message = response.Message });
        }
    }
}