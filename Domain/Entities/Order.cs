namespace EventDrivenOrders.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string CustomerName { get; init; }
        public decimal TotalAmount { get; private set; }
        public string Status { get; private set; } = "Created";

        public Order(string customerName, decimal totalAmount)
        {
            CustomerName = customerName;
            TotalAmount = totalAmount;
        }
        public void Pay() => Status = "Paid";
        public void Ship() => Status = "Shipped";
        public void Cancel() => Status = "Canceled";
        public override string ToString() => $"{CustomerName} Order with {TotalAmount}$ is {Status}";
    }
}
