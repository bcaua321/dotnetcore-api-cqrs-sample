using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ApiCQRS.Application.Commands
{
    public class ErrorNotification : INotification
    {
        public string Exception { get; set; }
        public string StackTrace { get; set; } 
    }
}