using EventDrivenOrders.Domain.Entities;

namespace EventDrivenOrders.Application.Storage
{
    public interface IOrderStore
    {
        void Add(Order order);
        Order Get(Guid id);
        IReadOnlyList<Order> GetAll();
    }
}
