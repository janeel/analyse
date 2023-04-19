namespace Orders.Commands;

public class CreateOrderCommand
{
    public decimal Amount { get; }
    public string Currency { get; }
    public string BuyOrSell { get; }
    public string AccountId { get; }

    public CreateOrderCommand(decimal amount, string currency, string buyOrSell, string accountId)
    {
        Amount = amount;
        Currency = currency;
        BuyOrSell = buyOrSell;
        AccountId = accountId;
    }
}