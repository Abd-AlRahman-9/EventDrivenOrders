using EventDrivenOrders.Domain.Entities;

namespace EventDrivenOrders.Domain.Events
{
    public class OrderCreatedEvent : IDomainEvent
    {
        public Order Order { get; }
        public DateTime CreatedAt { get; } = DateTime.Now;
        public OrderCreatedEvent (Order order) => Order = order;
    }
}
