using EventDrivenOrders.Domain.Events;

namespace EventDrivenOrders.Application.Events
{
    public interface IEventHandler<in TEvent> where TEvent : IDomainEvent
    {
        Task HandleAsync(TEvent @event);
    }
}
