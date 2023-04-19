namespace Orders.Commands;

public interface ICreateOrderCommandHandler
{
    Task<CommandResponse> Create(CreateOrderCommand command);
}