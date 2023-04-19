using Orders.Commands;
using Orders.Commands.Orders;
using Orders.Repository.Orders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ICreateOrderCommandHandler, CreateOrderCommandHandler>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();