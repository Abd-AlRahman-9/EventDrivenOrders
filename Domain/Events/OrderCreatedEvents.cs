using EventDrivenOrders.Domain.Entities;

namespace EventDrivenOrders.Domain.Events
{
    public class OrderCreatedEvents
    {
        public Order Order { get; }
        public DateTime CreatedAt { get; } = DateTime.Now;
        public OrderCreatedEvents (Order order) => Order = order;
    }
}
