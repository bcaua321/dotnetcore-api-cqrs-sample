using ApiCQRS.Application;
using ApiCQRS.Application.Commands;
using ApiCQRS.Application.Commands.UserCommands;
using ApiCQRS.Application.Commands.UserCommands.DTOs;
using ApiCQRS.Application.Enums;
using ApiCQRS.Application.Shared;
using ApiCQRS.Core.UserContext;
using MediatR;

namespace ApiCQRS.Application.Commands.UserCommands.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ResponseResult>
    {
        private readonly IMediator _mediator;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;

        public RegisterUserCommandHandler(IMediator mediator, IUserWriteOnlyRepository repository)
        {
            _mediator = mediator;
            _userWriteOnlyRepository = repository;
        }

        public async Task<ResponseResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User 
            { 
                Name = request.Nome, 
                LastName = request.Sobrenome,
                Email = request.Email,
                Password = request.Password,
            };

            try 
            {
                var result = await _userWriteOnlyRepository.Add(user);
                await _mediator.Publish(new RegisterUserNotification { Id = user.Id, Name = user.Name, LastName = user.LastName, Email = user.Email, IsEfetivado = true });
                return new ResponseResult(HttpResultEnum.Ok, new { Message = "Sucess in create user." });
            } catch(Exception ex) {
                await _mediator.Publish(new RegisterUserNotification { Id = user.Id, Name = user.Name, LastName = user.LastName, Email = user.Email, IsEfetivado = false });
                await _mediator.Publish(new ErrorNotification { Exception = ex.Message, StackTrace = ex.StackTrace });
                return new ResponseResult(HttpResultEnum.InternalServerError,new { Message = "Internal error." });
            }
        }
    }
}