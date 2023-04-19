namespace Orders.API.v1.Orders;

public class CreateOrderRequest
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public string BuyOrSell { get; set; }
    public string AccountId { get; set; }
}