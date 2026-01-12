using EventDrivenOrders.Application.Events;
using EventDrivenOrders.Domain.Events;

namespace EventDrivenOrders.Infrastructure.Handlers
{
    public class OrderPaidLoggingHandler : IEventHandler<OrderPaidEvent>
    {
        public Task HandleAsync(OrderPaidEvent @event)
        {
            Console.WriteLine($"[LOG] Order Paid | Id: {@event.Order.Id}");
            return Task.CompletedTask;
        }
    }
}
