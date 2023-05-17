using ApiCQRS.Application.Shared;
using MediatR;

namespace ApiCQRS.Application.Commands.UserCommands.DTOs
{
    public class DeleteUserCommand : IRequest<ResponseResult>
    {
        public Guid Id { get; set; }
    }
}