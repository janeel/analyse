namespace Orders.Repository.Accounts;

public class AccountRepository : IAccountRepository
{
    public async Task<bool> IsValid(string accountId)
    {
        return true;
    }
}