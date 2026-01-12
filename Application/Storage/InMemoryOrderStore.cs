using EventDrivenOrders.Domain.Entities;

namespace EventDrivenOrders.Application.Storage
{
    public class InMemoryOrderStore : IOrderStore
    {
        private readonly List<Order> _orders = new();

        public void Add(Order order) => _orders.Add(order);

        public Order Get(Guid id) => _orders.First(o => o.Id == id);

        public IReadOnlyList<Order> GetAll() => _orders.AsReadOnly();
    }
}
