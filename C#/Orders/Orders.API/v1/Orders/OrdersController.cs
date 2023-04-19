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
    public async Task<ActionResult> Create([FromBody] CreateOrderRequest orderRequest)
    {
        var commandResponse = await createOrderCommandHandler.Create(
            new CreateOrderCommand(orderRequest.Amount, orderRequest.Currency, orderRequest.BuyOrSell, orderRequest.AccountId));
        
        if (!commandResponse.Success)
        {
            return UnprocessableEntity(commandResponse.Error);
        }
        
        return Ok(commandResponse.Id);
    }
}