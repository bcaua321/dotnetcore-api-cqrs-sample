using MediatR;

namespace ApiCQRS.Application.Commands.UserCommands.DTOs
{
    public class UpdateUserCommand : IRequest<ResponseCommand>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; } 
    }
}