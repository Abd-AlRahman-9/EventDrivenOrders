using EventDrivenOrders.Domain.Events;
using System;

namespace EventDrivenOrders.Application.Events
{
    public class InMemoryEventBus
    {
        private readonly IServiceProvider _serviceProvidor;
        public InMemoryEventBus(IServiceProvider serviceProvidor)
        {
            _serviceProvidor = serviceProvidor;
        }

        public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IDomainEvent
        {
            var handlers = _serviceProvidor.GetServices<IEventHandler<TEvent>>();
            foreach (var handler in handlers)
            {
                await handler.HandleAsync(@event);
            }
        }
    }
}
