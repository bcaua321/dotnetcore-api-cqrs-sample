using ApiCQRS.Application;
using ApiCQRS.Application.Commands.Notifications;
using ApiCQRS.Application.Commands.UserCommands.DTOs;
using ApiCQRS.Application.Enums;
using ApiCQRS.Application.Shared;
using ApiCQRS.Core.UserContext;
using MediatR;

namespace ApiCQRS.Application.Commands.UserCommands.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResponseResult>
    {
        private readonly IMediator _mediator;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;

        public DeleteUserCommandHandler(IMediator mediator, IUserWriteOnlyRepository userWriteOnlyRepository, IUserReadOnlyRepository userReadOnlyRepository)
        {
            _mediator = mediator;
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _userReadOnlyRepository = userReadOnlyRepository;
        }
        
        public async Task<ResponseResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userReadOnlyRepository.FindById(request.Id);

            if(user is null)
            {
                await _mediator.Publish(new DeleteUserNotification { Id = user.Id, Name = user.Name, Email = user.Email, IsEfetivado = false });
                return new ResponseResult(HttpResultEnum.NotFound, new { Message = $"{request.Id} user do not exists" });
            }

            bool result = true; 

            try
            {
                result = await _userWriteOnlyRepository.Delete(user);
            } catch (Exception e) 
            {
                await _mediator.Publish(new ErrorNotification { Exception = e.Message, StackTrace = e.StackTrace });
            }

            if(!result) 
            {
                await _mediator.Publish(new DeleteUserNotification { Id = user.Id, Name = user.Name, Email = user.Email, IsEfetivado = false });
                return new ResponseResult(HttpResultEnum.InternalServerError, new { Message = $"Internal error" });
            }

            return new ResponseResult(HttpResultEnum.Ok, new { Message = "Success in exclude" });
        }
    }
}