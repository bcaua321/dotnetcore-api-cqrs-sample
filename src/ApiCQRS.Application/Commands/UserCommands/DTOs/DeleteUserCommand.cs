using MediatR;

namespace ApiCQRS.Application.Commands.UserCommands.DTOs
{
    public class DeleteUserCommand : IRequest<ResponseCommand>
    {
        public Guid Id { get; set; }
    }
}