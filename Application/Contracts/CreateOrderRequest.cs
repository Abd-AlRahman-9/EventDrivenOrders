namespace EventDrivenOrders.Application.Contracts
{
    public record CreateOrderRequest(string CustomerName, decimal Amount);
}
