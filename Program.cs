using EventDrivenOrders.Application.Contracts;
using EventDrivenOrders.Application.Events;
using EventDrivenOrders.Application.Notifications;
using EventDrivenOrders.Application.Services;
using EventDrivenOrders.Application.Storage;
using EventDrivenOrders.Domain.Events;
using EventDrivenOrders.Infrastructure.Handlers;
using EventDrivenOrders.Infrastructure.Notification;

namespace EventDrivenOrders
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.AddSingleton<InMemoryEventBus>();
            builder.Services.AddSingleton<IOrderStore, InMemoryOrderStore>();
            builder.Services.AddSingleton<OrderService>();
            builder.Services.AddSingleton<IEmailSender, ConsoleEmailSender>();
            builder.Services.AddSingleton<IEventHandler<OrderCreatedEvent>, OrderCreatedEmailHandler>();
            builder.Services.AddSingleton<IEventHandler<OrderCreatedEvent>, OrderCreatedLoggingHandler>();
            builder.Services.AddSingleton<IEventHandler<OrderPaidEvent>, OrderPaidLoggingHandler>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapPost("/orders", async (OrderService service, CreateOrderRequest request) =>
            {
                var order = await service.CreateOrderAsync(request.CustomerName, request.Amount);
                return Results.Created($"/orders/{order.Id}", order);
            });

            app.MapPost("/orders/{id:guid}/pay", async (OrderService service, Guid id) =>
            {
                await service.PayOrderAsync(id);
                return Results.Ok();
            });

            app.MapGet("/orders", (IOrderStore store) =>
            {
                return store.GetAll();
            });

            app.Run();
        }
    }
}
