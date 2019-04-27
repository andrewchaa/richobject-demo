using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using RichObject.Domain;
using RichObject.Domain.Repositories;

namespace RichObject.Data.Repositories
{
    public class CustomerRepository2I : ICustomerRepository2I
    {
        public async Task<CustomerData2I> Get(Guid customerId)
        {
            using (var conn = new SqlConnection())
            {
                var customerData = await conn.QuerySingleOrDefaultAsync<CustomerData2I>(
                    "SELECT * FROM Customers WHERE CustomerId = @customerId",
                    new {customerId});
                customerData.Addresses = await conn.QueryAsync<AddressData2I>(
                    "SELECT * FROM Addresses WHERE Customer",
                    new {customerId});

                return customerData;
            }
        }
    }
}