using Autofac.Extras.Moq;
using FluentAssertions;
using Moq;
using Orders.Commands.Orders;
using Orders.Repository.Accounts;
using Orders.Repository.Orders;
using Xunit.Spec;

namespace Orders.Commands.Test.Orders;

public class GivenValidAccount_WhenCreatingOrder  : ResultSpec<CreateOrderCommandHandler, CommandResponse>
{
    private const int OrderId = 1;
    
    private CreateOrderCommand buyOrderCommand;
    private Mock<IAccountRepository> accountRepository;
    private Mock<IOrderRepository> orderRepository;

    protected override Task ArrangeAsync(AutoMock mock)
    {
        buyOrderCommand = new CreateOrderCommand(77, "USD", "Buy", "123465789");
        
        SetupValidAccount(mock);
        SetupSuccessCreateOrderRepository(mock);
        
        return Task.CompletedTask;
    }
    
    private static void SetupValidAccount(AutoMock mock)
    {
        mock.Mock<IAccountRepository>()
            .Setup(x => x.IsValid(It.IsAny<string>()))
            .ReturnsAsync(true)
            .Verifiable();
    }

    private void SetupSuccessCreateOrderRepository(AutoMock mock)
    {
        orderRepository = mock.Mock<IOrderRepository>();
        orderRepository
            .Setup(x => x.Create(
                It.IsAny<decimal>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()))
            .ReturnsAsync(OrderId)
            .Verifiable();
    }
    
    protected override Task<CommandResponse> ActAsync(CreateOrderCommandHandler subject) => subject.Create(buyOrderCommand);

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
        Result.Id.Should().Be(OrderId);
    } 
}