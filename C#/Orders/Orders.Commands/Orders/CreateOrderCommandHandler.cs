using Orders.Repository.Orders;

namespace Orders.Commands.Orders;

public class CreateOrderCommandHandler : ICreateOrderCommandHandler
{
    private readonly IOrderRepository orderRepository;

    public CreateOrderCommandHandler(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
    }

    public async Task<int> Create(CreateOrderCommand command)
    {
        return await orderRepository.Create(command.Amount, command.Currency, command.BuyOrSell, command.AccountId);
    }
}