namespace Orders.Repository.Orders;

public interface IOrderRepository
{
    Task<int> Create(decimal amount, string currency, string buyOrSell, string accountId);
}