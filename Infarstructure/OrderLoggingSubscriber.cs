using EventDrivenOrders.Domain.Events;

namespace EventDrivenOrders.Infarstructure
{
    public class OrderLoggingSubscriber
    {
        public void OnOrderCreated(OrderCreatedEvents @event)
        {
            Console.WriteLine($"[LOG] Order Created | Id: {@event.Order.Id} | Amount: {@event.Order.TotalAmount}");
        }
        public void OnOrderPaid(OrderPaidEvents @event)
        {
            Console.WriteLine($"[LOG] Order Paid | Id:{@event.Order.Id}");
        }
    }
}
