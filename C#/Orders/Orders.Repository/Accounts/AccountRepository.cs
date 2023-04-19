namespace Orders.Repository.Accounts;

public class AccountRepository : IAccountRepository
{
    public async Task<bool> IsValid(string accountId)
    {
        // hard coded to only return true with dummy accountId
        return accountId == "123465789";
    }
}