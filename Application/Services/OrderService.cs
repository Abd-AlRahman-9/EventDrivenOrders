using EventDrivenOrders.Application.Events;
using EventDrivenOrders.Application.Storage;
using EventDrivenOrders.Domain.Entities;
using EventDrivenOrders.Domain.Events;

namespace EventDrivenOrders.Application.Services
{
    public class OrderService
    {
        private readonly InMemoryEventBus _eventBus;
        private readonly IOrderStore _store;

        public OrderService(InMemoryEventBus eventBus, IOrderStore store)
        {
            _store = store;
            _eventBus = eventBus;
        }
        public async Task<Order> CreateOrderAsync(string customerName, decimal totalAmount)
        {
            var order = new Order(customerName, totalAmount);
            _store.Add(order);

            await _eventBus.PublishAsync(new OrderCreatedEvent(order));
            return order;
        }
        public async Task PayOrderAsync(Guid orderId)
        {
            var order = _store.Get(orderId);
            order.Pay();

            await _eventBus.PublishAsync(new OrderPaidEvent(order));
        } 
    }
}
