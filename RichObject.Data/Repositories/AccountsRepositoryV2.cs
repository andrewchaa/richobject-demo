using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using RichObject.Accounts;

namespace RichObject.Data.Repositories
{
    public class AccountsRepositoryV2 : IAccountsRepositoryV2
    {
        private readonly string _connectionString;

        public AccountsRepositoryV2(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Account> GetAccount(Guid accountId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var accountDto = await connection.QuerySingleAsync<AccountDto>(
                    "SELECT * FROM Accounts WHERE AccountId = @accountId",
                    new {accountId});

                return new Account(accountDto.AccountId, accountDto.AccountName);
            }
        }
    }

    public interface IAccountsRepositoryV2
    {
    }
}
