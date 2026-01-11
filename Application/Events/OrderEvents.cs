using EventDrivenOrders.Domain.Events;
namespace EventDrivenOrders.Application.Events
{
    public delegate void OrderCreatedHandler(OrderCreatedEvents @event);
    public delegate void OrderPaidHandler(OrderPaidEvents @event);
    public delegate void OrderCancelledHandler(OrderCancelledEvents @event);
    public delegate void OrderShippedHandler(OrderShippedEvents @event);
}
