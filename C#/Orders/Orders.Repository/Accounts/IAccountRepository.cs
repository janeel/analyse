namespace Orders.Repository.Accounts;

public interface IAccountRepository
{
    Task<bool> IsValid(string accountId);
}