using EventDrivenOrders.Application.Events;
using EventDrivenOrders.Application.Notifications;
using EventDrivenOrders.Domain.Events;

namespace EventDrivenOrders.Infrastructure.Handlers
{
    public class OrderCreatedEmailHandler: IEventHandler<OrderCreatedEvent>
    {
        private readonly IEmailSender _emailSender;
        public OrderCreatedEmailHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task HandleAsync(OrderCreatedEvent @event)
        {
            await _emailSender.SendAsync(
                $"{@event.Order.Email}",
                "Order Created Successfully",
                $"Your Order {@event.Order.Id} was created with amount {@event.Order.TotalAmount}"
            );
        }
    }
}
