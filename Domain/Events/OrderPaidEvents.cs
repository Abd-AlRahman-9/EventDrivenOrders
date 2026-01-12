using EventDrivenOrders.Domain.Entities;

namespace EventDrivenOrders.Domain.Events
{
    public class OrderPaidEvent : IDomainEvent
    {
        public Order Order { get; }
        public DateTime PaidAt { get; } = DateTime.Now;
        public OrderPaidEvent(Order order) => Order = order;
    }
}
