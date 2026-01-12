using EventDrivenOrders.Application.Events;
using EventDrivenOrders.Domain.Events;

namespace EventDrivenOrders.Infrastructure.Handlers
{
    public class OrderCreatedLoggingHandler : IEventHandler<OrderCreatedEvent>
    {
        public Task HandleAsync(OrderCreatedEvent @event)
        {
            Console.WriteLine($"[LOG] Order Created | Id: {@event.Order.Id} | Amount: {@event.Order.TotalAmount}");
            return Task.CompletedTask;
        }
    }
}
