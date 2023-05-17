using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCQRS.Application.Shared;
using MediatR;

namespace ApiCQRS.Application.Commands.UserCommands.DTOs
{
    public class RegisterUserCommand : IRequest<ResponseResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; } 
    }
}