using Autofac.Extras.Moq;
using FluentAssertions;
using Moq;
using Orders.Commands.Orders;
using Orders.Repository.Accounts;
using Orders.Repository.Orders;
using Xunit.Spec;

namespace Orders.Commands.Test.Orders;

public class GivenInvalidAccount_WhenCreatingOrder : ResultSpec<CreateOrderCommandHandler, CommandResponse>
{
    private CreateOrderCommand buyOrderCommand;
    private Mock<IOrderRepository> orderRepository;

    protected override Task ArrangeAsync(AutoMock mock)
    {
        buyOrderCommand = new CreateOrderCommand(77, "USD", "Buy", "123465789");
        
        SetupInvalidAccount(mock);
        orderRepository = mock.Mock<IOrderRepository>();
        
        return Task.CompletedTask;
    }

    private static void SetupInvalidAccount(AutoMock mock)
    {
        mock.Mock<IAccountRepository>()
            .Setup(x => x.IsValid(It.IsAny<string>()))
            .ReturnsAsync(false)
            .Verifiable();
    }

    protected override Task<CommandResponse> ActAsync(CreateOrderCommandHandler subject) => subject.Create(buyOrderCommand);

    [Fact]
    public void should_not_save_to_database()
    {
        orderRepository.Verify(
            x => x.Create(buyOrderCommand.Amount, buyOrderCommand.Currency, buyOrderCommand.BuyOrSell,
                buyOrderCommand.AccountId), Times.Never);
    }
    
    [Fact]
    public void should_return_error()
    {
        Result.Error.Should().NotBeEmpty();
    } 
}
    