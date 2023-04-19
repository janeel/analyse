using Orders.Commands;
using Orders.Commands.Orders;
using Orders.Repository.Accounts;
using Orders.Repository.Orders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ICreateOrderCommandHandler, CreateOrderCommandHandler>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();