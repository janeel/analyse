namespace Orders.Repository.Orders;

public class OrderRepository : IOrderRepository
{
    public async Task<int> Create(decimal amount, string currency, string buyOrSell, string accountId)
    {
        return await Task.FromResult(1);
    }
}