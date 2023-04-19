using Orders.Commands;
using Orders.Commands.Orders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ICreateOrderCommandHandler, CreateOrderCommandHandler>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();