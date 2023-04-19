namespace Orders.Commands;

public interface ICreateOrderCommandHandler
{
    Task<int> Create(CreateOrderCommand command);
}