using EventDrivenOrders.Application.Notifications;

namespace EventDrivenOrders.Infrastructure.Notification
{
    public class ConsoleEmailSender : IEmailSender
    {
        public Task SendAsync(string to, string subject, string body)
        {
            Console.WriteLine("Sending Email:");
            Console.WriteLine($"To: {to}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Body: {body}");
            return Task.CompletedTask;
        }
    }
}
