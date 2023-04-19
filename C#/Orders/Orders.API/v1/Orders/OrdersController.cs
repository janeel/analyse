using Microsoft.AspNetCore.Mvc;
using Orders.Commands;

namespace Orders.API.v1.Orders;

[ApiController]
public class OrdersController : ControllerBase
{
    private readonly ICreateOrderCommandHandler createOrderCommandHandler;
    
    public OrdersController(ICreateOrderCommandHandler createOrderCommandHandler)
    {
        this.createOrderCommandHandler = createOrderCommandHandler;
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateOrderRequest orderRequest)
    {
        var orderId = await createOrderCommandHandler.Create(
            new CreateOrderCommand(orderRequest.Amount, orderRequest.Currency, orderRequest.BuyOrSell,
                orderRequest.AccountId));
        return Ok(orderId);
    }
}