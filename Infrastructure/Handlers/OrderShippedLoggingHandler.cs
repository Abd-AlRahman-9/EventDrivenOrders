using EventDrivenOrders.Application.Events;
using EventDrivenOrders.Domain.Events;

namespace EventDrivenOrders.Infrastructure.Handlers
{
    public class OrderShippedLoggingHandler : IEventHandler<OrderShippedEvent>
    {
        public Task HandleAsync(OrderShippedEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
