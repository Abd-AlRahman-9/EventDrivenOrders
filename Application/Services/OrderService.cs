using EventDrivenOrders.Application.Events;
using EventDrivenOrders.Domain.Entities;
using EventDrivenOrders.Domain.Events;

namespace EventDrivenOrders.Application.Services
{
    public class OrderService
    {
        public event OrderCreatedHandler OrderCreated;
        public event OrderPaidHandler OrderPaid;
        public event OrderCancelledHandler OrderCancelled;
        public event OrderShippedHandler OrderShipped;

        private readonly List<Order> _orders = new List<Order>();

        public Order CreateOrder(string customerName, decimal totalAmount)
        {
            var order = new Order(customerName, totalAmount);
            _orders.Add(order);

            OrderCreated?.Invoke(new OrderCreatedEvents(order));
            return order;
        }
        public void PayOrder(Guid orderId)
        {
            var order = _orders.FirstOrDefault(o=>o.Id == orderId);
            order.Pay();

            OrderPaid.Invoke(new OrderPaidEvents(order));
        } 
        public IReadOnlyList<Order> GetOrders()=> _orders.AsReadOnly();
    }
}
