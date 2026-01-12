using EventDrivenOrders.Application.Events;
using EventDrivenOrders.Domain.Events;

namespace EventDrivenOrders.Infrastructure.Handlers
{
    public class OrderCancelledLoggingHandler : IEventHandler<OrderCancelledEvent>
    {
        public Task HandleAsync(OrderCancelledEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
