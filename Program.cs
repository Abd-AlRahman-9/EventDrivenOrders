using EventDrivenOrders.Application.Contracts;
using EventDrivenOrders.Application.Services;
using EventDrivenOrders.Infarstructure;

namespace EventDrivenOrders
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.AddSingleton<OrderService>();
            builder.Services.AddSingleton<OrderLoggingSubscriber>();

            var app = builder.Build();

            var orderService = app.Services.GetRequiredService<OrderService>();
            var logger = app.Services.GetRequiredService<OrderLoggingSubscriber>();

            orderService.OrderCreated+=logger.OnOrderCreated;
            orderService.OrderPaid += logger.OnOrderPaid;


            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapPost("/orders", (OrderService service, CreateOrderRequest request) =>
            {
                var order = service.CreateOrder(request.CustomerName, request.Amount);
                return Results.Created($"/orders/{order.Id}", order);
            });

            app.MapPost("/orders/{id:guid}/pay", (OrderService service, Guid id) =>
            {
                service.PayOrder(id);
                return Results.Ok();
            });

            app.MapGet("/orders", (OrderService service) =>
            {
                return service.GetOrders();
            });

            app.Run();
        }
    }
}
