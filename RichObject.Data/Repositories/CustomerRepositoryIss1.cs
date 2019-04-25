using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using RichObject.Domain;
using RichObject.Domain.Models;
using RichObject.Domain.Repositories;

namespace RichObject.Data.Repositories
{
    public class CustomerRepositoryIss1 : ICustomerRepositoryIss1
    {
        public async Task<Customer1Iss> Get(Guid customerId)
        {
            using (var conn = new SqlConnection())
            {
                var customer = await conn.QuerySingleOrDefaultAsync<Customer1Iss>(
                    "SELECT * FROM Customers WHERE CustomerId = @customerId",
                    new {customerId});
                customer.Addresses = await conn.QueryAsync<AddressIss1>(
                    "SELECT * FROM Addresses WHERE Customer",
                    new {customerId});

                return customer;
            }
        }
    }
}