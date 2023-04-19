using Autofac.Extras.Moq;
using FluentAssertions;
using Moq;
using Orders.Commands.Orders;
using Orders.Repository.Orders;
using Xunit.Spec;

namespace Orders.Commands.Test.Orders;

public class WhenValidAccount  : ResultSpec<CreateOrderCommandHandler, int>
{
    private CreateOrderCommand buyOrderCommand;
    private const int OrderId = 1;
    private Mock<IOrderRepository> orderRepository;

    protected override Task ArrangeAsync(AutoMock mock)
    {
        buyOrderCommand = new CreateOrderCommand(100, "USD", "Buy", "123465789");
        orderRepository = mock.Mock<IOrderRepository>();
        orderRepository
            .Setup(x => x.Create(
                It.IsAny<decimal>(), 
                It.IsAny<string>(), 
                It.IsAny<string>(), 
                It.IsAny<string>()))
            .ReturnsAsync(OrderId)
            .Verifiable();
        return Task.CompletedTask;
    }

    protected override Task<int> ActAsync(CreateOrderCommandHandler subject) => subject.Create(buyOrderCommand);

    [Fact]
    public void should_save_to_database()
    {
        orderRepository.Verify(
            x => x.Create(buyOrderCommand.Amount, buyOrderCommand.Currency, buyOrderCommand.BuyOrSell,
                buyOrderCommand.AccountId), Times.Once);
    } 
    
    [Fact]
    public void should_return_orderId()
    {
        Result.Should().Be(OrderId);
    } 
}