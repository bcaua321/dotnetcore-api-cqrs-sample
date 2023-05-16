using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ApiCQRS.Application.Commands.Notifications
{
    public class UpdateUserNotification : INotification
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }        
        public bool IsEfetivado  { get; set; }
    }
}