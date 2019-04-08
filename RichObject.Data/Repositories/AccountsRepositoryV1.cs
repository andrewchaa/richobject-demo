using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace RichObject.Data.Repositories
{
    public class AccountsRepositoryV1 : IAccountsRepositoryV1
    {
        private readonly string _connectionString;

        public AccountsRepositoryV1(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<AccountDto> GetAccount(Guid accountId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QuerySingleAsync<AccountDto>(
                    "SELECT * FROM Accounts WHERE AccountId = @accountId",
                    new {accountId});
            }
        }
    }

    public interface IAccountsRepositoryV1
    {
    }

}
