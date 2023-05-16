using ApiCQRS.Application.Commands.Notifications;
using ApiCQRS.Application.Commands.UserCommands;
using MediatR;

namespace ApiCQRS.Application.Commands
{
    public class LogEventHandler : 
                            INotificationHandler<RegisterUserNotification>,
                            INotificationHandler<UpdateUserNotification>,
                            INotificationHandler<ErrorNotification>
    {
        public LogEventHandler()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
        }

        public Task Handle(RegisterUserNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CREATE: '{notification.Id} - {notification.Name} | {notification.IsEfetivado}'");
            });
        }

        public Task Handle(UpdateUserNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"UPDATE: '{notification.Id} - {notification.Name} | {notification.IsEfetivado}'");
            });
        }

        public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                
                Console.WriteLine($"ERROR: '{notification.Exception} \n {notification.StackTrace}'");
            });
        }
    }
}