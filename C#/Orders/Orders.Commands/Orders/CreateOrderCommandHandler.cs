using Orders.Repository.Accounts;
using Orders.Repository.Orders;

namespace Orders.Commands.Orders;

public class CreateOrderCommandHandler : ICreateOrderCommandHandler
{
    private readonly IOrderRepository orderRepository;
    private readonly IAccountRepository accountRepository;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IAccountRepository accountRepository)
    {
        this.orderRepository = orderRepository;
        this.accountRepository = accountRepository;
    }

    public async Task<CommandResponse> Create(CreateOrderCommand command)
    {
        var isValidAccount = await accountRepository.IsValid(command.AccountId);
        if (!isValidAccount)
        {
            return CommandResponse.MakeForError("Account does not exist");
        }
        
        var orderId = await orderRepository.Create(command.Amount, command.Currency, command.BuyOrSell, command.AccountId);
        return CommandResponse.MakeWithId(orderId);
    }
}