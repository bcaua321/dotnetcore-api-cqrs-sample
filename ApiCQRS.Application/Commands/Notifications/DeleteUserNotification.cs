using MediatR;

namespace ApiCQRS.Application.Commands.Notifications
{
    public class DeleteUserNotification : INotification
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }         
        public bool IsEfetivado  { get; set; }
    }
}