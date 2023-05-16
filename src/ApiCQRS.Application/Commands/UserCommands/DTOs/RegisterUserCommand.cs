using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ApiCQRS.Application.Commands.UserCommands.DTOs
{
    public class RegisterUserCommand : IRequest<ResponseCommand>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; } 
    }
}