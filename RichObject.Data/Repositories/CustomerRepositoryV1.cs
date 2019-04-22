using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using RichObject.Domain;

namespace RichObject.Data.Repositories
{
    public class CustomerRepositoryV1 : ICustomerRepositoryV1
    {
        public async Task<CustomerV1> Get(Guid customerId)
        {
            using (var conn = new SqlConnection())
            {
                var customer = await conn.QuerySingleOrDefaultAsync<CustomerV1>(
                    "SELECT * FROM Customers WHERE CustomerId = @customerId",
                    new {customerId});
                customer.Addresses = await conn.QueryAsync<AddressV1>(
                    "SELECT * FROM Addresses WHERE Customer",
                    new {customerId});

                return customer;
            }
        }
    }
}