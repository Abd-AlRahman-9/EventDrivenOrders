namespace EventDrivenOrders.Application.Notifications
{
    public interface IEmailSender
    {
        Task SendAsync(string to, string subject, string body); 
    }
}
