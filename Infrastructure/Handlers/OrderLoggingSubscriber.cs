using EventDrivenOrders.Domain.Events;

namespace EventDrivenOrders.Infrastructure.Handlers
{
    public class OrderLoggingSubscriber
    {
        public void OnOrderCreated(OrderCreatedEvent @event)
        {
            Console.WriteLine($"[LOG] Order Created | Id: {@event.Order.Id} | Amount: {@event.Order.TotalAmount}");
        }
        public void OnOrderPaid(OrderPaidEvent @event)
        {
            Console.WriteLine($"[LOG] Order Paid | Id:{@event.Order.Id}");
        }
    }
}
