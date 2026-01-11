using EventDrivenOrders.Domain.Entities;

namespace EventDrivenOrders.Domain.Events
{
    public class OrderPaidEvents
    {
        public Order Order { get; }
        public DateTime PaidAt { get; } = DateTime.Now;
        public OrderPaidEvents(Order order) => Order = order;
    }
}
